using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Kodo.Graphics;

namespace Kodo_s_Monitor
{
    class MonitorVideoElement : Wnd3DElement
    {
        static readonly byte[] mediaShaderVertexBytecode = new byte[]
        {
             68,  88,  66,  67, 116, 121, 134, 141, 215, 216, 178, 103,  77, 124, 199,  46,
            202, 138, 155, 229,   1,   0,   0,   0,  64,   4,   0,   0,   6,   0,   0,   0,
             56,   0,   0,   0,  44,   1,   0,   0,  72,   2,   0,   0, 196,   2,   0,   0,
            148,   3,   0,   0, 232,   3,   0,   0,  65, 111, 110,  57, 236,   0,   0,   0,
            236,   0,   0,   0,   0,   2, 254, 255, 184,   0,   0,   0,  52,   0,   0,   0,
              1,   0,  36,   0,   0,   0,  48,   0,   0,   0,  48,   0,   0,   0,  36,   0,
              1,   0,  48,   0,   0,   0,   0,   0,   4,   0,   1,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   1,   2, 254, 255,  81,   0,   0,   5,   5,   0,  15, 160,
              0,   0, 128,  63,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
             31,   0,   0,   2,   5,   0,   0, 128,   0,   0,  15, 144,  31,   0,   0,   2,
              5,   0,   1, 128,   1,   0,  15, 144,   4,   0,   0,   4,   0,   0,  15, 128,
              0,   0,  36, 144,   5,   0,  64, 160,   5,   0,  21, 160,   9,   0,   0,   3,
              0,   0,   4, 192,   0,   0, 228, 128,   3,   0, 228, 160,   9,   0,   0,   3,
              1,   0,   1, 128,   0,   0, 228, 128,   1,   0, 228, 160,   9,   0,   0,   3,
              1,   0,   2, 128,   0,   0, 228, 128,   2,   0, 228, 160,   9,   0,   0,   3,
              0,   0,   1, 128,   0,   0, 228, 128,   4,   0, 228, 160,   4,   0,   0,   4,
              0,   0,   3, 192,   0,   0,   0, 128,   0,   0, 228, 160,   1,   0, 228, 128,
              1,   0,   0,   2,   0,   0,   8, 192,   0,   0,   0, 128,   1,   0,   0,   2,
              0,   0,   3, 224,   1,   0, 228, 144, 255, 255,   0,   0,  83,  72,  68,  82,
             20,   1,   0,   0,  64,   0,   1,   0,  69,   0,   0,   0,  89,   0,   0,   4,
             70, 142,  32,   0,   0,   0,   0,   0,   4,   0,   0,   0,  95,   0,   0,   3,
            114,  16,  16,   0,   0,   0,   0,   0,  95,   0,   0,   3,  50,  16,  16,   0,
              1,   0,   0,   0, 103,   0,   0,   4, 242,  32,  16,   0,   0,   0,   0,   0,
              1,   0,   0,   0, 101,   0,   0,   3,  50,  32,  16,   0,   1,   0,   0,   0,
            104,   0,   0,   2,   1,   0,   0,   0,  54,   0,   0,   5, 114,   0,  16,   0,
              0,   0,   0,   0,  70,  18,  16,   0,   0,   0,   0,   0,  54,   0,   0,   5,
            130,   0,  16,   0,   0,   0,   0,   0,   1,  64,   0,   0,   0,   0, 128,  63,
             17,   0,   0,   8,  18,  32,  16,   0,   0,   0,   0,   0,  70,  14,  16,   0,
              0,   0,   0,   0,  70, 142,  32,   0,   0,   0,   0,   0,   0,   0,   0,   0,
             17,   0,   0,   8,  34,  32,  16,   0,   0,   0,   0,   0,  70,  14,  16,   0,
              0,   0,   0,   0,  70, 142,  32,   0,   0,   0,   0,   0,   1,   0,   0,   0,
             17,   0,   0,   8,  66,  32,  16,   0,   0,   0,   0,   0,  70,  14,  16,   0,
              0,   0,   0,   0,  70, 142,  32,   0,   0,   0,   0,   0,   2,   0,   0,   0,
             17,   0,   0,   8, 130,  32,  16,   0,   0,   0,   0,   0,  70,  14,  16,   0,
              0,   0,   0,   0,  70, 142,  32,   0,   0,   0,   0,   0,   3,   0,   0,   0,
             54,   0,   0,   5,  50,  32,  16,   0,   1,   0,   0,   0,  70,  16,  16,   0,
              1,   0,   0,   0,  62,   0,   0,   1,  83,  84,  65,  84, 116,   0,   0,   0,
              8,   0,   0,   0,   1,   0,   0,   0,   0,   0,   0,   0,   4,   0,   0,   0,
              4,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,  82,  68,  69,  70, 200,   0,   0,   0,   1,   0,   0,   0,
             76,   0,   0,   0,   1,   0,   0,   0,  28,   0,   0,   0,   0,   4, 254, 255,
              0,   1,   0,   0, 160,   0,   0,   0,  60,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              1,   0,   0,   0,   1,   0,   0,   0,  67, 111, 110, 115, 116,  97, 110, 116,
             66, 117, 102, 102, 101, 114,   0, 171,  60,   0,   0,   0,   1,   0,   0,   0,
            100,   0,   0,   0,  64,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
            124,   0,   0,   0,   0,   0,   0,   0,  64,   0,   0,   0,   2,   0,   0,   0,
            144,   0,   0,   0,   0,   0,   0,   0,  87, 111, 114, 108, 100,  86, 105, 101,
            119,  80, 114, 111, 106, 101,  99, 116, 105, 111, 110,   0,   3,   0,   3,   0,
              4,   0,   4,   0,   0,   0,   0,   0,   0,   0,   0,   0,  77, 105,  99, 114,
            111, 115, 111, 102, 116,  32,  40,  82,  41,  32,  72,  76,  83,  76,  32,  83,
            104,  97, 100, 101, 114,  32,  67, 111, 109, 112, 105, 108, 101, 114,  32,  49,
             48,  46,  49,   0,  73,  83,  71,  78,  76,   0,   0,   0,   2,   0,   0,   0,
              8,   0,   0,   0,  56,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              3,   0,   0,   0,   0,   0,   0,   0,   7,   7,   0,   0,  65,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,   1,   0,   0,   0,
              3,   3,   0,   0,  80,  79,  83,  73,  84,  73,  79,  78,   0,  84,  69,  88,
             67,  79,  79,  82,  68,   0, 171, 171,  79,  83,  71,  78,  80,   0,   0,   0,
              2,   0,   0,   0,   8,   0,   0,   0,  56,   0,   0,   0,   0,   0,   0,   0,
              1,   0,   0,   0,   3,   0,   0,   0,   0,   0,   0,   0,  15,   0,   0,   0,
             68,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,
              1,   0,   0,   0,   3,  12,   0,   0,  83,  86,  95,  80,  79,  83,  73,  84,
             73,  79,  78,   0,  84,  69,  88,  67,  79,  79,  82,  68,   0, 171, 171, 171,
        };

        static readonly byte[] mediaPixelShaderBytecode = new byte[]
        {
             68,  88,  66,  67,  17,  95, 156, 240, 176,  91,  20,  86,  13, 145, 189, 157,
            169, 168, 104, 252,   1,   0,   0,   0, 180,   4,   0,   0,   6,   0,   0,   0,
             56,   0,   0,   0, 108,   1,   0,   0, 220,   2,   0,   0,  88,   3,   0,   0,
             40,   4,   0,   0, 128,   4,   0,   0,  65, 111, 110,  57,  44,   1,   0,   0,
             44,   1,   0,   0,   0,   2, 255, 255,   0,   1,   0,   0,  44,   0,   0,   0,
              0,   0,  44,   0,   0,   0,  44,   0,   0,   0,  44,   0,   2,   0,  36,   0,
              0,   0,  44,   0,   0,   0,   0,   0,   1,   0,   1,   0,   1,   2, 255, 255,
             81,   0,   0,   5,   0,   0,  15, 160, 115, 128, 128, 189, 115, 128,   0, 191,
              0,   0, 128,  63,   0,   0,   0,   0,  81,   0,   0,   5,   1,   0,  15, 160,
            129,  10, 149,  63, 157,  74, 204,  63,   0,   0,   0,   0,  84,  26,   1,  64,
             81,   0,   0,   5,   2,   0,  15, 160, 129,  10, 149,  63,   7, 149, 200, 190,
            172,  30,  80, 191,   0,   0,   0,   0,  31,   0,   0,   2,   0,   0,   0, 128,
              0,   0,   3, 176,  31,   0,   0,   2,   0,   0,   0, 144,   0,   8,  15, 160,
             31,   0,   0,   2,   0,   0,   0, 144,   1,   8,  15, 160,  66,   0,   0,   3,
              0,   0,  15, 128,   0,   0, 228, 176,   1,   8, 228, 160,  66,   0,   0,   3,
              1,   0,  15, 128,   0,   0, 228, 176,   0,   8, 228, 160,   1,   0,   0,   2,
              1,   0,   6, 128,   0,   0, 208, 128,   2,   0,   0,   3,   0,   0,   7, 128,
              1,   0, 228, 128,   0,   0, 212, 160,  90,   0,   0,   4,   1,   0,  17, 128,
              0,   0, 232, 128,   1,   0, 228, 160,   1,   0, 170, 160,   8,   0,   0,   3,
              1,   0,  18, 128,   0,   0, 228, 128,   2,   0, 228, 160,  90,   0,   0,   4,
              1,   0,  20, 128,   0,   0, 228, 128,   1,   0, 236, 160,   1,   0, 170, 160,
              1,   0,   0,   2,   1,   0,   8, 128,   0,   0, 170, 160,   1,   0,   0,   2,
              0,   8,  15, 128,   1,   0, 228, 128, 255, 255,   0,   0,  83,  72,  68,  82,
            104,   1,   0,   0,  64,   0,   0,   0,  90,   0,   0,   0,  90,   0,   0,   3,
              0,  96,  16,   0,   0,   0,   0,   0,  88,  24,   0,   4,   0, 112,  16,   0,
              0,   0,   0,   0,  85,  85,   0,   0,  88,  24,   0,   4,   0, 112,  16,   0,
              1,   0,   0,   0,  85,  85,   0,   0,  98,  16,   0,   3,  50,  16,  16,   0,
              1,   0,   0,   0, 101,   0,   0,   3, 242,  32,  16,   0,   0,   0,   0,   0,
            104,   0,   0,   2,   2,   0,   0,   0,  69,   0,   0,   9, 242,   0,  16,   0,
              0,   0,   0,   0,  70,  16,  16,   0,   1,   0,   0,   0,  70, 126,  16,   0,
              0,   0,   0,   0,   0,  96,  16,   0,   0,   0,   0,   0,  69,   0,   0,   9,
            242,   0,  16,   0,   1,   0,   0,   0,  70,  16,  16,   0,   1,   0,   0,   0,
             70, 126,  16,   0,   1,   0,   0,   0,   0,  96,  16,   0,   0,   0,   0,   0,
             54,   0,   0,   5,  98,   0,  16,   0,   0,   0,   0,   0,   6,   1,  16,   0,
              1,   0,   0,   0,   0,   0,   0,  10, 114,   0,  16,   0,   0,   0,   0,   0,
             70,   2,  16,   0,   0,   0,   0,   0,   2,  64,   0,   0, 115, 128, 128, 189,
            115, 128,   0, 191, 115, 128,   0, 191,   0,   0,   0,   0,  15,  32,   0,  10,
             18,  32,  16,   0,   0,   0,   0,   0, 134,   0,  16,   0,   0,   0,   0,   0,
              2,  64,   0,   0, 129,  10, 149,  63, 157,  74, 204,  63,   0,   0,   0,   0,
              0,   0,   0,   0,  16,  32,   0,  10,  34,  32,  16,   0,   0,   0,   0,   0,
             70,   2,  16,   0,   0,   0,   0,   0,   2,  64,   0,   0, 129,  10, 149,  63,
              7, 149, 200, 190, 172,  30,  80, 191,   0,   0,   0,   0,  15,  32,   0,  10,
             66,  32,  16,   0,   0,   0,   0,   0,  70,   0,  16,   0,   0,   0,   0,   0,
              2,  64,   0,   0, 129,  10, 149,  63,  84,  26,   1,  64,   0,   0,   0,   0,
              0,   0,   0,   0,  54,   0,   0,   5, 130,  32,  16,   0,   0,   0,   0,   0,
              1,  64,   0,   0,   0,   0, 128,  63,  62,   0,   0,   1,  83,  84,  65,  84,
            116,   0,   0,   0,   9,   0,   0,   0,   2,   0,   0,   0,   0,   0,   0,   0,
              2,   0,   0,   0,   4,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   2,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              2,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,  82,  68,  69,  70, 200,   0,   0,   0,
              0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,  28,   0,   0,   0,
              0,   4, 255, 255,   0,   1,   0,   0, 158,   0,   0,   0, 124,   0,   0,   0,
              3,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
              0,   0,   0,   0,   1,   0,   0,   0,   1,   0,   0,   0, 139,   0,   0,   0,
              2,   0,   0,   0,   5,   0,   0,   0,   4,   0,   0,   0, 255, 255, 255, 255,
              0,   0,   0,   0,   1,   0,   0,   0,   1,   0,   0,   0, 148,   0,   0,   0,
              2,   0,   0,   0,   5,   0,   0,   0,   4,   0,   0,   0, 255, 255, 255, 255,
              1,   0,   0,   0,   1,   0,   0,   0,   5,   0,   0,   0, 116, 101, 120, 116,
            117, 114, 101,  83,  97, 109, 112, 108, 101, 114,   0, 116, 101, 120, 116, 117,
            114, 101,  89,   0, 116, 101, 120, 116, 117, 114, 101,  85,  86,   0,  77, 105,
             99, 114, 111, 115, 111, 102, 116,  32,  40,  82,  41,  32,  72,  76,  83,  76,
             32,  83, 104,  97, 100, 101, 114,  32,  67, 111, 109, 112, 105, 108, 101, 114,
             32,  49,  48,  46,  49,   0, 171, 171,  73,  83,  71,  78,  80,   0,   0,   0,
              2,   0,   0,   0,   8,   0,   0,   0,  56,   0,   0,   0,   0,   0,   0,   0,
              1,   0,   0,   0,   3,   0,   0,   0,   0,   0,   0,   0,  15,   0,   0,   0,
             68,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,
              1,   0,   0,   0,   3,   3,   0,   0,  83,  86,  95,  80,  79,  83,  73,  84,
             73,  79,  78,   0,  84,  69,  88,  67,  79,  79,  82,  68,   0, 171, 171, 171,
             79,  83,  71,  78,  44,   0,   0,   0,   1,   0,   0,   0,   8,   0,   0,   0,
             32,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0,   0,
              0,   0,   0,   0,  15,   0,   0,   0,  83,  86,  95,  84,  97, 114, 103, 101,
            116,   0, 171, 171,
        };

        FFmpegEngine ffmpegEngine;

        D3DDevice renderDevice;
        D3DDeviceContext renderDeviceContext;

        D3DTexture2D mediaFrameTexture;
        D3DShaderResourceView mediaFrameTextureYView;
        D3DShaderResourceView mediaFrameTextureUVView;

        Vec4 mediaFrameRect;

        static readonly D3DInputElement[] mediaShaderInputDesc = new D3DInputElement[]
        {
            new D3DInputElement(D3DSemantic.POSITION, 0, DxgiFormat.R32G32B32_Float, 0, uint.MaxValue, D3DInputClassification.PerVertex,   0),
            new D3DInputElement(D3DSemantic.TEXCOORD, 0, DxgiFormat.R32G32_Float,    0, uint.MaxValue, D3DInputClassification.PerVertex,   0),
        };

        MediaVertex[] mediaVertices = new MediaVertex[]
        {
            new MediaVertex(new Vec3(0, 0, 1), new Vec2(0, 0)),
            new MediaVertex(new Vec3(60, 0, 1), new Vec2(1, 0)),
            new MediaVertex(new Vec3(0, 40, 1), new Vec2(0, 1)),

            new MediaVertex(new Vec3(60, 0, 1), new Vec2(1, 0)),
            new MediaVertex(new Vec3(60, 40, 1), new Vec2(1, 1)),
            new MediaVertex(new Vec3(0, 40, 1), new Vec2(0, 1)),
        };

        [StructLayout(LayoutKind.Sequential)]
        readonly struct MediaVertex
        {
            public readonly Vec3 Position;
            public readonly Vec2 Texture;
            public MediaVertex(Vec3 position, Vec2 texture)
            {
                Position = position;
                Texture = texture;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        readonly struct MediaConstantBuffer
        {
            public readonly Mat4x4 WorldViewProjection;
            public MediaConstantBuffer(Mat4x4 wvp)
            {
                WorldViewProjection = wvp;
            }
        }

        D3DInputLayout mediaShaderInput;
        D3DVertexShader mediaShaderVertex;
        D3DPixelShader mediaShaderPixel;
        D3DBuffer mediaConstantBuffer;
        D3DBuffer mediaVertexBuffer;
        Mat4x4 mediaTransform;

        D3DBlendState mediaFrameBlending;
        D3DSamplerState mediaFrameTextureSampler;
        D3DRasterizerState mediaFrameRasterizing;

        D3DRenderTargetView mediaRenderTargetView;
        D3DDepthStencilView mediaDepthStencilView;

        public MonitorVideoElement(WndElement element) : base(element)
        {
        }

        protected override void OnCreatedDevice(D3DDevice d3dDevice, D3DDeviceContext d3dContext)
        {
            renderDevice = d3dDevice;
            renderDeviceContext = d3dContext;

            mediaShaderInput = new D3DInputLayout(d3dDevice, mediaShaderInputDesc, mediaShaderVertexBytecode);
            mediaShaderVertex = new D3DVertexShader(d3dDevice, mediaShaderVertexBytecode);
            mediaShaderPixel = new D3DPixelShader(d3dDevice, mediaPixelShaderBytecode);

            mediaConstantBuffer = D3DBuffer.Create(d3dDevice,
                D3DBind.ConstantBuffer,
                D3DUsage.Default,
                D3DAccess.None,
                typeof(MediaConstantBuffer));
            mediaVertexBuffer = D3DBuffer.Create(d3dDevice,
                D3DBind.VertexBuffer,
                D3DUsage.Dynamic,
                D3DAccess.Write,
                mediaVertices);

            mediaFrameTextureSampler = new D3DSamplerState(d3dDevice,
                D3DTextureAddressing.Clamp,
                D3DTextureAddressing.Clamp,
                D3DTextureFiltering.Anisotropic,
                16);

            mediaFrameRasterizing = new D3DRasterizerState(d3dDevice,
                D3DFill.Solid,
                D3DCull.Back,
                true);
            mediaFrameBlending = new D3DBlendState(d3dDevice);

            var pathVariable = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\FFmpeg\\;{pathVariable}");

            ffmpegEngine = new FFmpegEngine(HandleMediaEvent);

            // rtsp_transport       tcp
            // thread_queue_size    1024
            // buffer_size          31250000
            // max_delay            5000000
            // reorder_queue_size   1000

            ffmpegEngine.SetSourceOption("hw", "true");
            ffmpegEngine.SetSourceOption("rtsp_transport", "tcp");
            ffmpegEngine.SetSourceOption("stimeout", "2000000"); // TCP I/O timeout [us]
            //ffmpegEngine.SetSource("rtsp://janttonen:pema12345@192.168.1.64:554/Streaming/Channels/101?transportmode=unicast&profile=Profile_1");
            ffmpegEngine.SetSource("rtsp://janttonen:pema1234@192.168.1.66:554/onvif-media/media.amp");
            ffmpegEngine.Play();
        }

        protected override void OnCreatedTarget(D3DRenderTargetView d3dTarget, D3DDepthStencilView d3dDepthStencil)
        {
            mediaRenderTargetView = d3dTarget;
            mediaDepthStencilView = d3dDepthStencil;
        }

        double mediaFrameShouldEnd = 0;

        protected override void OnDraw(D3DDeviceContext d3dContext)
        {
            if (ffmpegEngine.HasFrame(out double framePts, out double frameDur))
            {
                ffmpegEngine.TransferFrame(mediaFrameTexture);
                //Console.WriteLine($"{mediaFrameShouldEnd:F3}");
                //Console.WriteLine($"{framePts:F3} {frameDur:F3} {framePts + frameDur:F3}");

                /*if (mediaFrameShouldEnd == 0 || framePts - mediaFrameShouldEnd <= 0.002)
                {
                    ffmpegEngine.TransferFrame(mediaFrameTexture);

                    if (framePts != 0)
                    {
                        mediaFrameShouldEnd = framePts + frameDur;
                    }
                    else
                    {
                        mediaFrameShouldEnd += frameDur;
                    }
                }*/
            }

            // input-assembler
            d3dContext.IASetInputLayout(mediaShaderInput);
            d3dContext.IASetVertexBuffer(mediaVertexBuffer);
            d3dContext.IASetPrimitiveTopology(PrimitiveTopology.Triangles);
            // vertex shader
            d3dContext.VSSetShader(mediaShaderVertex);
            d3dContext.VSSetConstantBuffer(mediaConstantBuffer);
            // pixel shader
            d3dContext.PSSetShader(mediaShaderPixel);
            d3dContext.PSSetSampler(mediaFrameTextureSampler);
            d3dContext.PSSetResources(mediaFrameTextureYView, mediaFrameTextureUVView);
            // rasterizer - viewport and scissor is set by Wnd3DElement
            d3dContext.RSSetState(mediaFrameRasterizing);
            // output-merger
            d3dContext.OMSetBlendState(mediaFrameBlending);
            d3dContext.OMSetRenderTarget(mediaRenderTargetView, mediaDepthStencilView);
            // issue draw commands
            d3dContext.ClearDepth(mediaDepthStencilView);
            d3dContext.Draw(mediaVertices.Length);
        }

        void HandleMediaEvent(FFmpegEngineEvent engineEvent)
        {
            switch (engineEvent)
            {
                case FFmpegEngineEvent.Started:
                    CreateMediaResources(ffmpegEngine.GetSourceDescription());
                    break;
                case FFmpegEngineEvent.Stopped:
                    break;
                case FFmpegEngineEvent.Error:
                    Console.WriteLine(ffmpegEngine.GetError());
                    break;
                default:
                    break;
            }
        }

        void CreateMediaResources(FFmpegStreamDesc ffmpegStream)
        {
            Console.WriteLine($"Hardware Decoding : {ffmpegStream.IsHardwareDecoded}");
            Console.WriteLine($"FPS : {ffmpegStream.FramesPerSecond}");

            mediaFrameRect = new Vec4(0, 0, ffmpegStream.Width, ffmpegStream.Height);

            if (ffmpegStream.IsHardwareDecoded)
            {
                mediaFrameTexture = new D3DTexture2D(renderDevice,
                    ffmpegStream.Width,
                    ffmpegStream.Height,
                    DxgiFormat.NV12,
                    D3DBind.ShaderResource,
                    D3DUsage.Default,
                    D3DAccess.None,
                    D3DMisc.Shared);
            }
            else
            {
                mediaFrameTexture = new D3DTexture2D(renderDevice,
                    ffmpegStream.Width,
                    ffmpegStream.Height,
                    DxgiFormat.NV12,
                    D3DBind.ShaderResource,
                    D3DUsage.Dynamic,
                    D3DAccess.Write);
            }

            mediaFrameTextureYView = new D3DShaderResourceView(renderDevice, mediaFrameTexture, DxgiFormat.R8_UNORM);
            mediaFrameTextureUVView = new D3DShaderResourceView(renderDevice, mediaFrameTexture, DxgiFormat.R8G8_UNORM);

            mediaTransform = Mat4x4.Ortho(0, mediaFrameRect.Right, mediaFrameRect.Bottom, 0);
            mediaVertices = new MediaVertex[]
            {
                new MediaVertex(new Vec3(0,                  0,                   0), new Vec2(0, 0)),
                new MediaVertex(new Vec3(ffmpegStream.Width, 0,                   0), new Vec2(1, 0)),
                new MediaVertex(new Vec3(0,                  ffmpegStream.Height, 0), new Vec2(0, 1)),

                new MediaVertex(new Vec3(ffmpegStream.Width, 0,                   0), new Vec2(1, 0)),
                new MediaVertex(new Vec3(ffmpegStream.Width, ffmpegStream.Height, 0), new Vec2(1, 1)),
                new MediaVertex(new Vec3(0,                  ffmpegStream.Height, 0), new Vec2(0, 1)),
            };

            // update GPU resources
            var newMediaConstantBuffer = new MediaConstantBuffer(Mat4x4.Transpose(mediaTransform));
            renderDeviceContext.UpdateGPUResource(mediaConstantBuffer, newMediaConstantBuffer);
            renderDeviceContext.UpdateGPUResource(mediaVertexBuffer, mediaVertices, D3DMap.WriteDiscard);
        }
    }

    class MonitorWnd : Wnd
    {
        MonitorVideoElement videoElement;

        public MonitorWnd(WndManager manager)
            : base(manager)
        {
            videoElement = new MonitorVideoElement(Root);
        }

        protected override void OnCreated()
        {
            base.OnCreated();
        }

        protected override void OnUpdate()
        {
            videoElement.Area = AreaOfContent;
        }
    }

    class Program
    {
        static void Main()
        {
            using (WndManager manager = new WndManager())
            {
                using (MonitorWnd window = new MonitorWnd(manager))
                {
                    window.Create("Kodo's Monitor", new Vec4(float.NaN, float.NaN, 1280, 720), new Vec4(3, 30, 3, 3), Color.UnpackRGB(0x485460), Color.UnpackRGB(0x1e272e), 0);

                    while (!window.ShouldClose)
                    {
                        manager.PollEvents();

                        window.Update();
                        window.Draw();
                    }
                }
            }
        }
    }
}
