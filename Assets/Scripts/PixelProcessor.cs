using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PixelProcessor : AssetPostprocessor
{
    public void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;

        importer.textureType = TextureImporterType.Sprite;
        importer.filterMode = FilterMode.Point;
        importer.alphaIsTransparency = true;
        importer.spritePixelsPerUnit = 32;
        
        importer.SaveAndReimport();
    }
}
