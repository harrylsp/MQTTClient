using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTClient
{
    public partial class Form1 : Form
    {
        public MqttClient mqttClient = null;

        public List<MqttClient> mqttClients = new List<MqttClient>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var username = this.txtUserName.Text;
            var password = this.txtPassword.Text;

            ClientStart(username, password);
            //return;

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 50000; i++)
            //    {
            //        //Thread.Sleep(500);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000; i++)
            //    {
            //        //Thread.Sleep(10);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000; i++)
            //    {
            //        //Thread.Sleep(10);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000; i++)
            //    {
            //        //Thread.Sleep(10);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000; i++)
            //    {
            //        //Thread.Sleep(10);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 2000; i++)
            //    {
            //        //Thread.Sleep(10);
            //        ClientStart();
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 5000; i++)
            //    {
            //        //Thread.Sleep(500);
            //        ClientStart();
            //    }
            //});
        }

        public async void ClientStart(string username = "test-host:admin-test", string password = "test")
        {
            try
            {
                var tcpServer = string.IsNullOrWhiteSpace(this.txtIP.Text?.Trim()) ? "127.0.0.1" : this.txtIP.Text.Trim();
                var tcpPort = 1883;
                var mqttUser = username;
                var mqttPassword = password;
                var clientId = "lsp" + Guid.NewGuid();

                //mqttUser = "test-host:admin-test";
                //mqttPassword = "test";

                var mqttFactory = new MqttFactory();

                var options = new MqttClientOptions
                {
                    ClientId = clientId,
                    ProtocolVersion = MQTTnet.Formatter.MqttProtocolVersion.V311,
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        Server = tcpServer,
                        Port = tcpPort
                    },
                    WillDelayInterval = 10,
                    WillMessage = new MqttApplicationMessage
                    {
                        Topic = $"LastWill/{clientId}",
                        Payload = Encoding.UTF8.GetBytes("I Lost the Connection!"),
                        QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce
                    }
                };

                if (options.ChannelOptions == null)
                {
                    throw new InvalidOperationException();
                }

                if (!string.IsNullOrWhiteSpace(mqttUser))
                {
                    options.Credentials = new MqttClientCredentials
                    {
                        Username = mqttUser,
                        Password = Encoding.UTF8.GetBytes(mqttPassword)
                    };
                }

                options.CleanSession = true;
                options.KeepAlivePeriod = TimeSpan.FromSeconds(10);

                mqttClient = mqttFactory.CreateMqttClient() as MqttClient;
                //mqttClient = mqttFactory.CreateMqttClient() as MqttClient;
                //mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnMqttClientConnected);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(new Action<MqttClientConnectedEventArgs>(e =>
                {
                    LogManager.WriteLogEx(LOGLEVEL.INFO, "客户端已连接");
                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += "客户端已连接" + Environment.NewLine;
                    }));
                    //mqttClient.SubscribeAsync("lsp");
                    //LogManager.WriteLogEx(LOGLEVEL.INFO, "订阅lsp");
                }));

                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(new Action<MqttClientDisconnectedEventArgs>(e =>
                {
                    LogManager.WriteLogEx(LOGLEVEL.INFO, "客户端已断开连接");
                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += "客户端已断开连接" + Environment.NewLine;
                    }));

                    //mqttClient.ConnectAsync(options, CancellationToken.None);
                }));

                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(e =>
                {
                    string text = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string topic = e.ApplicationMessage.Topic;
                    string qos = e.ApplicationMessage.QualityOfServiceLevel.ToString();
                    string retained = e.ApplicationMessage.Retain.ToString();

                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += $"客户端接收消息 >>Topic：{topic}; Qos：{qos}; Retained：{retained}" + Environment.NewLine;
                        this.txtMessage.Text += $"客户端接收消息 >>Msg：{text}" + Environment.NewLine;
                    }));

                    LogManager.WriteLogEx(LOGLEVEL.INFO, $"客户端接收消息 >>Topic：{topic}; Qos：{qos}; Retained：{retained}");
                    LogManager.WriteLogEx(LOGLEVEL.INFO, $"客户端接收消息 >>Msg：{text}");
                }));

                //mqttClients.Add(mqttClient);
                await mqttClient.ConnectAsync(options);

                LogManager.WriteLogEx(LOGLEVEL.INFO, $"客户端{options.ClientId}尝试连接...");
                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端{options.ClientId}尝试连接..." + Environment.NewLine;
                }));
            }
            catch (Exception ex)
            {
                LogManager.WriteLogEx(LOGLEVEL.ERROR, $"客户端尝试连接出错：" + ex.Message);

                //await mqttClients[0].ReconnectAsync();

                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端尝试连接出错：" + ex.Message + Environment.NewLine;
                }));
            }
        }

        private Task OnMqttClientConnected(MqttClientConnectedEventArgs obj)
        {
            throw new NotImplementedException();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ClientStop();
        }

        public async void ClientStop()
        {
            try
            {
                if (mqttClient == null)
                {
                    return;
                }

                await mqttClient.DisconnectAsync();
                mqttClient = null;
            }
            catch (Exception ex)
            {
                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端尝试断开连接出错：" + ex.Message + Environment.NewLine;
                }));
            }
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                if (mqttClient == null || !mqttClient.IsConnected)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtTopic.Text))
                {
                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += $"客户端订阅主题不能为空" + Environment.NewLine;
                    }));

                    return;
                }

                ClientSubscribeTopic(this.txtTopic.Text);
            }
            catch (Exception ex)
            {
                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端订阅出错：" + ex.Message + Environment.NewLine;
                }));
            }
        }

        public async void ClientSubscribeTopic(string topic)
        {
            await mqttClient.SubscribeAsync(topic);

            this.txtMessage.BeginInvoke(new Action(() =>
            {
                this.txtMessage.Text += $"客户端{mqttClient.Options.CleanSession}订阅{topic}成功!" + Environment.NewLine;
            }));
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublic_Click(object sender, EventArgs e)
        {
            try
            {
                if (mqttClient == null || !mqttClient.IsConnected)
                {
                    return;
                }

                var topic = this.txtTopic.Text;
                var payload = this.txtPayload.Text;

                if (string.IsNullOrWhiteSpace(topic))
                {
                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += $"客户端发布主题不能为空" + Environment.NewLine;
                    }));

                    return;
                }

                if (string.IsNullOrWhiteSpace(payload))
                {
                    this.txtMessage.BeginInvoke(new Action(() =>
                    {
                        this.txtMessage.Text += $"客户端发布内容不能为空" + Environment.NewLine;
                    }));

                    return;
                }

                ClientPublishTopic(topic, payload);
            }
            catch (Exception ex)
            {
                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端发布主题出错：" + ex.Message + Environment.NewLine;
                }));

                ClientStop();
            }

        }

        public async void ClientPublishTopic(string topic, string payload)
        {
            try
            {
                var message = new MqttApplicationMessage
                {
                    Topic = topic,
                    Payload = Encoding.UTF8.GetBytes(payload),
                    QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce,
                    Retain = true
                };

                await mqttClient.PublishAsync(message, CancellationToken.None);

                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端{mqttClient.Options.ClientId}发布主题{topic}成功" + Environment.NewLine;
                }));
            }
            catch (Exception ex)
            {
                this.txtMessage.BeginInvoke(new Action(() =>
                {
                    this.txtMessage.Text += $"客户端{mqttClient.Options.ClientId}发布主题{topic}出错：" + ex.Message + Environment.NewLine;
                }));
            }
        }
    }
}
