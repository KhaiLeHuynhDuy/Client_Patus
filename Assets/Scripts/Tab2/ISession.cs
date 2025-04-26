public interface ISession2
{
	bool isConnected();

	void setHandler(IMessageHandler2 messageHandler);

	void connect(string host, int port);

	void sendMessage(Message2 message);

	void close();
}
