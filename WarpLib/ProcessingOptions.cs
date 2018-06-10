﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warp.Tools;

namespace Warp
{
    public abstract class ProcessingOptionsBase : WarpBase
    {
        [WarpSerializable]
        public decimal PixelSizeX { get; set; }
        [WarpSerializable]
        public decimal PixelSizeY { get; set; }
        [WarpSerializable]
        public decimal PixelSizeAngle { get; set; }
        [WarpSerializable]
        public decimal BinTimes { get; set; }
        [WarpSerializable]
        public string GainPath { get; set; }
        [WarpSerializable]
        public float3 Dimensions { get; set; }

        public decimal PixelSizeMean => (PixelSizeX + PixelSizeY) * 0.5M;
        public decimal PixelSizeDelta => (PixelSizeX - PixelSizeY) * 0.5M;
        public decimal DownsampleFactor => (decimal)Math.Pow(2.0, (double)BinTimes);
        public decimal BinnedPixelSizeX => PixelSizeX * DownsampleFactor;
        public decimal BinnedPixelSizeY => PixelSizeY * DownsampleFactor;
        public decimal BinnedPixelSizeMean => PixelSizeMean * DownsampleFactor;
        public decimal BinnedPixelSizeDelta => PixelSizeDelta * DownsampleFactor;
        

        protected bool Equals(ProcessingOptionsBase other)
        {
            return PixelSizeX == other.PixelSizeX &&
                   PixelSizeY == other.PixelSizeY &&
                   PixelSizeAngle == other.PixelSizeAngle &&
                   GainPath == other.GainPath &&
                   BinTimes == other.BinTimes;
        }

        public static bool operator ==(ProcessingOptionsBase left, ProcessingOptionsBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProcessingOptionsBase left, ProcessingOptionsBase right)
        {
            return !Equals(left, right);
        }
    }
}