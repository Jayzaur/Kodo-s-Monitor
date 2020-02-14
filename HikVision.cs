using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kodo_s_Monitor
{
    class HikVision : IDisposable
    {
        bool initialized;

        int userId = -1;
        int playId = -1;

        public HikVision()
        {
            initialized = NET_DVR_Init();

            if (initialized == false)
                throw new NotImplementedException();
        }

        public bool Login(string address, string userName, string userPassword, int port = 8000)
        {
            if (userId >= 0)
            {
                Logout();
            }

            userId = NET_DVR_Login_V30(address, port, userName, userPassword, out _);

            if (userId >= 0)
            {
                return true;
            }

            return false;
        }

        public void Logout()
        {
            if (userId >= 0)
            {
                NET_DVR_Logout(userId);
                userId = -1;
            }
        }

        public bool StartStream(IntPtr streamingHandle)
        {
            if (playId >= 0)
            {
                StopStream();
            }

            var previewInfo = new NET_DVR_PREVIEWINFO();
            previewInfo.WindowHandle = streamingHandle;
            previewInfo.ChannelNumber = 1;
            previewInfo.StreamType = 0;
            previewInfo.LinkMode = 0;
            previewInfo.Blocked = true;
            previewInfo.DisplayBufNum = 1;
            previewInfo.ProtoType = 0;
            previewInfo.PreviewMode = 0;

            playId = NET_DVR_RealPlay_V40(userId, ref previewInfo, null, IntPtr.Zero);

            if (playId >= 0)
            {
                return true;
            }

            return false;
        }

        public void StopStream()
        {
            if (playId >= 0)
            {
                NET_DVR_StopRealPlay(playId);
                playId = -1;
            }
        }

        public void Dispose()
        {
            if (initialized)
            {
                NET_DVR_Cleanup();
                initialized = false;
            }
        }

        public const string HCNetSDK = @".\HikVision\HCNetSDK.dll";

        [DllImport(HCNetSDK)]
        static extern bool NET_DVR_Init();
        [DllImport(HCNetSDK)]
        static extern bool NET_DVR_Cleanup();

        [DllImport(HCNetSDK)]
        static extern int NET_DVR_Login_V30(string cameraAddress, int cameraPort, string userName, string userPassword, out NET_DVR_DEVICEINFO_V30 cameraInfo);
        [DllImport(HCNetSDK)]
        static extern bool NET_DVR_Logout(int id);

        [DllImport(HCNetSDK)]
        static extern int NET_DVR_GetLastError();

        [DllImport(HCNetSDK)]
        static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);
        [DllImport(HCNetSDK)]
        static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        delegate void REALDATACALLBACK(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser);

        [StructLayout(LayoutKind.Sequential)]
        struct NET_DVR_DEVICEINFO_V30
        {
            /// <summary>
            /// Device serial number.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] Serial;
            /// <summary>
            /// Rest of the data lumbed together.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] Blob;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct NET_DVR_PREVIEWINFO
        {
            public int ChannelNumber;
            public uint StreamType;
            public uint LinkMode;
            public IntPtr WindowHandle;
            public bool Blocked;
            public bool PassbackRecord;
            public byte PreviewMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
            public byte[] byStreamID;
            public byte ProtoType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint DisplayBufNum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 216, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }
    }
}
