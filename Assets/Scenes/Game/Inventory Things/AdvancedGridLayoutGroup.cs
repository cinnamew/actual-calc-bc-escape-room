using UnityEngine;
 using UnityEngine.UI;
 
 public class AdvancedGridLayoutGroup : GridLayoutGroup
 {
     [SerializeField] protected int cellsPerLine = 8;
     [SerializeField] protected float aspectRatio = 1f;
 
     public override void SetLayoutHorizontal()
     {
         float width = (this.GetComponent<RectTransform>()).rect.width;
         float useableWidth = width - this.padding.horizontal - (this.cellsPerLine - 1) * this.spacing.x;
         float cellWidth = useableWidth / cellsPerLine;
         //print("cellWidth: " + cellWidth + "cells per line: " + m_cellsPerLine + " useable width: " + useableWidth);
         this.cellSize = new Vector2(cellWidth, cellWidth * this.aspectRatio);
         base.SetLayoutHorizontal();
     }
 }