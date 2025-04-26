public interface IMessageHandler2
{
	void onMessage(Message2 message);

	void onConnectionFail(bool isMain);

	void onDisconnected(bool isMain);

	void onConnectOK(bool isMain);
}
