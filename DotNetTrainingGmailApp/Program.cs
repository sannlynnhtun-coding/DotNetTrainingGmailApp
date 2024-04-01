using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;

List<string> emails = new List<string>();

using ImapClient imapClient = new();
imapClient.Connect("imap.gmail.com", 993, true);
imapClient.Authenticate("fill_email", "fill_app_password");
imapClient.Inbox.Open(FolderAccess.ReadOnly);
var uids = await imapClient.Inbox.SearchAsync(SearchQuery.HasGMailLabel("DotNetTrainingBatch4"));
foreach (var uid in uids)
{
    var mimeMessage = imapClient.Inbox.GetMessage(uid);
    //if (!mimeMessage.Subject.Contains("DotNetTraining")) continue;

    string email = mimeMessage.From.Mailboxes.First().Address;
    Console.WriteLine(email);
    if (!emails.Any(x => x == email))
        emails.Add(email);
}
imapClient.Disconnect(true);

Console.ReadKey();

var result = string.Join(", ", emails);
Console.WriteLine(result);

Console.ReadKey();