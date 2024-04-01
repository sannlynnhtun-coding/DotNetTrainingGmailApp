1. Create App Password https://support.google.com/accounts/answer/185833
2. Install Mailkit
3. Write down the code 
```
using (var imapClient = new ImapClient())
{
	imapClient.Connect("imap.example.com", 993, true);
	imapClient.Authenticate("fill_email", "fill_app_password");
	imapClient.Inbox.Open(FolderAccess.ReadOnly);
	var uids = imapClient.Inbox.Search(SearchQuery.All);
	foreach (var uid in uids)
	{
		var mimeMessage = imapClient.Inbox.GetMessage(uid);
		Console.WriteLine(mimeMessage.Subject);
	}
	imapClient.Disconnect(true);
}
```
SearchQuery.HasGMailLabel https://mimekit.net/docs/html/M_MailKit_Search_SearchQuery_HasGMailLabel.htm