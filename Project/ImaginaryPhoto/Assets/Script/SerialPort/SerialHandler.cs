using UnityEngine;
using System.Collections;
using System.Threading;
using System.IO.Ports;

/*
 * シリアル通信のハンドラー
 */
public class SerialHandler : MonoBehaviour
{
	// デリゲート設定(お決まり)
	public delegate void SerialDataReceivedEventHandler(string message);
	public event SerialDataReceivedEventHandler OnDataReceived;

	// 接続先
	public string PortNumber = "/dev/tty.usbmodem1421";

	// 通信速度
	public int Rate = 115200;

	// 接続に関するもの
	private SerialPort serialPort;
	private Thread thread;

	// 接続中かどうか
	private bool IsConnecting = false;

	// 受け取った文字列
	private string receiveMessage;

	// 文字列を受けっとたかどうか
	private bool isReceived = false;

	void Awake()
	{
		Open();
	}

	void Update()
	{
		if (isReceived) 
		{
			OnDataReceived(receiveMessage);
			isReceived = false;
		}
	}

	void OnDestroy()
	{
		Close();
	}

	// 接続を開く
	private void Open()
	{
		serialPort = new SerialPort(PortNumber, Rate, Parity.None, 8, StopBits.One);
		serialPort.Open();

		IsConnecting = true;

		thread = new Thread(Read);
		thread.Start();
	}

	// 接続を閉じる
	private void Close()
	{
		IsConnecting = false;

		if (serialPort != null && serialPort.IsOpen) 
		{
			serialPort.Close();
			serialPort.Dispose();
		}

		if (thread != null && thread.IsAlive) 
		{
			thread.Abort();
			thread.Join();
		}
	}

	// 文字列を読み
	private void Read()
	{
		while (IsConnecting && serialPort != null && serialPort.IsOpen)
		{
			try
			{
				receiveMessage = serialPort.ReadLine();
				isReceived = true;

			}
			catch (System.Exception e)
			{
				Debug.LogWarning(e.Message);
			}
		}
	}
}