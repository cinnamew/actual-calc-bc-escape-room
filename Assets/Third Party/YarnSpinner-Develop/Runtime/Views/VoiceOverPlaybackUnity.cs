﻿using System;
using System.Collections;
using UnityEngine;

namespace Yarn.Unity {
    /// <summary>
    /// Handles playback of voice over <see cref="AudioClip"/>s referenced
    /// on <see cref="YarnProgram"/>s.
    /// </summary>
    public class VoiceOverPlaybackUnity : DialogueViewBase {
        /// <summary>
        /// The fade out time when <see cref="FinishCurrentLine"/> is
        /// called.
        /// </summary>
        public float fadeOutTimeOnLineFinish = 0.05f;

        [SerializeField]
        private AudioSource audioSource;

        /// <summary>
        /// When true, the <see cref="DialogueRunner"/> has signaled to
        /// finish the current line asap.
        /// </summary>
        private bool finishCurrentLine = false;

        private void Awake() {
            if (!audioSource) {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.spatialBlend = 0f;
            }
        }

        /// <summary>
        /// Start playback of the associated voice over <see
        /// cref="AudioClip"/> of the given <see cref="LocalizedLine"/>.
        /// </summary>
        /// <param name="dialogueLine"></param>
        /// <returns></returns>
        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished) {
            finishCurrentLine = false;

            if (!(dialogueLine is AudioLocalizedLine audioLine)) {
                Debug.LogError($"Playing voice over failed because {nameof(RunLine)} expected to receive an {nameof(AudioLocalizedLine)}, but instead received a {dialogueLine.GetType()}. Is your {nameof(DialogueRunner)} set up to use a {nameof(AudioLineProvider)}?", gameObject);
                onDialogueLineFinished();
                return;
            }

            // Get the localized voice over audio clip
            var voiceOverClip = audioLine.AudioClip;

            if (!voiceOverClip) {
                Debug.Log("Playing voice over failed since the AudioClip of the voice over audio language or the base language was null.", gameObject);
                onDialogueLineFinished();
                return;
            }
            if (audioSource.isPlaying) {
                // Usually, this shouldn't happen because the
                // DialogueRunner finishes and ends a line first
                audioSource.Stop();
            }
            audioSource.PlayOneShot(voiceOverClip);

            StartCoroutine(DoPlayback(onDialogueLineFinished));
            
        }

        private IEnumerator DoPlayback(Action onDialogueLineFinished) {

            // The audioSource started playing before this coroutine
            // started, so as long as the line hasn't been interrupted, we
            // don't need to do anything except wait.
            while (audioSource.isPlaying && !finishCurrentLine) {
                yield return null;
            }

            // But if the line _does_ become interrupted, we need to wrap
            // up the playback as quickly as we can. We do this here with a
            // fade-out to zero over fadeOutTimeOnLineFinish seconds.
            if (audioSource.isPlaying && finishCurrentLine) {
                // Fade out voice over clip            
                float lerpPosition = 0f;
                float volumeFadeStart = audioSource.volume;
                while (audioSource.volume != 0) {
                    lerpPosition += Time.unscaledDeltaTime / fadeOutTimeOnLineFinish;
                    audioSource.volume = Mathf.Lerp(volumeFadeStart, 0, lerpPosition);
                    yield return null;
                }
                audioSource.Stop();
                audioSource.volume = volumeFadeStart;
            } else {
                audioSource.Stop();
            }

            // We've finished our playback at this point, either by waiting
            // normally or by interrupting it with a fadeout. We can now
            // signal that the line delivery has finished.
            onDialogueLineFinished();
        }

        /// <summary>
        /// Yarn Spinner's implementation of voice over playback does
        /// nothing when presenting an option.
        /// </summary>
        /// <param name="dialogueOptions"></param>
        /// <param name="onOptionSelected"></param>
        public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected) {
            // Do nothing
        }

        public override void OnLineStatusChanged(LocalizedLine dialogueLine)
        {
            switch (dialogueLine.Status)
            {
                case LineStatus.Running:
                    // Nothing to do here - continue running.
                    break;
                case LineStatus.Interrupted:
                    // The user wants us to wrap up the audio quickly. The
                    // DoPlayback coroutine will apply the fade out defined
                    // by fadeOutTimeOnLineFinish.
                    finishCurrentLine = true;
                    break;
                case LineStatus.Delivered:
                    // The line has finished delivery on all views. Nothing
                    // left to do for us, since the audio will have already
                    // finished playing out.
                    break;
                case LineStatus.Ended:
                    // The line is being dismissed; we should ensure that
                    // audio playback has ended.
                    audioSource.Stop();            
                    break;
            }
        }

        public override void DismissLine(Action onDismissalComplete)
        {
            // Nothing left to do here - the audio playback will have
            // already ended.
            onDismissalComplete();
        }
    }
}

