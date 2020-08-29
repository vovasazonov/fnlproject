using Svt.Caspar;
using Svt.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    /// <summary>
    /// Use this static class to manipulate with casparCG.
    /// This class have extensions functions.
    /// </summary>
    static internal class CasparFNL
    {
        public static CasparDevice Device { get => _device; private set => _device = value; }
        private static CasparDevice _device = null;
        public static CasparCGDataCollection Data { get => _data; private set => _data = value; }
        private static CasparCGDataCollection _data = null;

        static CasparFNL()
        {
            _device = new CasparDevice();
            _data = new CasparCGDataCollection();
        }

        /// <summary>
        /// Set data and send to casparCG.
        /// </summary>
        /// <param name="keyValues"></param>
        static public void SendData(Dictionary<string, string> keyValues)
        {
            // Clear old data
            _data.Clear();

            try
            {
                // Set data.
                foreach (var dic in keyValues)
                {
                    _data.SetData(dic.Key, dic.Value);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
            finally
            {
                // Send data to channel.
                if (_device.IsConnected && _device.Channels.Count > 0)
                {
                    _device.Channels[Properties.Settings.Default.CasparChannel].
                        CG.Update(Properties.Settings.Default.GraphicsLayerClock, _data);
                }
            }
        }

        /// <summary>
        /// Set data and send to casparCG.
        /// </summary>
        static public void SendData(string key, string value)
        {
            SendData(new Dictionary<string, string>()
            {
                {key,value }
            });
        }

        /// <summary>
        /// Invoke method via channel.
        /// </summary>
        /// <param name="name"></param>
        static public void InvokeMethod(string name)
        {
            if (_device.IsConnected && _device.Channels.Count > 0)
            {
                _device.Channels[Properties.Settings.Default.CasparChannel].
                    CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static public void StopGrpahic()
        {
            if (Device.IsConnected && Device.Channels.Count > 0)
            {
                Device.Channels[Properties.Settings.Default.CasparChannel].
                    CG.Stop(Properties.Settings.Default.GraphicsLayerClock);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static public void StartGraphic()
        {
            if (Device.IsConnected && Device.Channels.Count > 0)
            {
                Device.Channels[Properties.Settings.Default.CasparChannel].
                    CG.Add(Properties.Settings.Default.GraphicsLayerClock,
                    Properties.Settings.Default.TemplateNameClock,
                    true,
                    Data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static public void ClearGraphic()
        {
            try
            {
                CasparFNL.Device.Channels[Properties.Settings.Default.CasparChannel].CG.Clear();
                CasparFNL.Device.Channels[Properties.Settings.Default.CasparChannel].Clear();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }

        /// <summary>
        /// Connect/disconnect device.
        /// </summary>
        /// <param name="hostName"></param>
        static public void Connect(string hostName)
        {
            try
            {
                if (!CasparFNL.Device.IsConnected)
                {
                    CasparFNL.Device.Settings.Hostname = hostName;
                    CasparFNL.Device.Settings.Port = 5250;
                    CasparFNL.Device.Connect();
                }
                else
                {
                    CasparFNL.Device.Disconnect();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }



        }

    }
}
