using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TuneECU
{

public class Warning : Form
{
	private IContainer components;

	private Button Ignore;

	private Button Accept;

	public TextBox textBoxDescription;

	private RichTextBox licenseTextBox;

	public string strRTF_fr = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036\\deflangfe1036{\\fonttbl{\\f0\\fswiss\\fprq2\\fcharset0 Tahoma;}{\\f1\\fswiss\\fprq2\\fcharset0 Arial;}}\r\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\nowidctlpar\\b\\f0\\fs20 Contrat de licence du logiciel\\b0\\par\r\n\\fs16\\par\r\n\\fs20 Ceci est un contrat l\\'e9gal entre vous, l'utilisateur final, et l'auteur du logiciel. Lorsque vous installez/utilisez le logiciel TuneECU vous \\'eates consid\\'e9r\\'e9 comme ayant accept\\'e9 tous les termes et les conditions d\\'e9crits dans ce document.\\par\r\n\\fs16\\par\r\n\\b\\fs20 Logiciel\\b0\\par\r\n\\fs16\\par\r\n\\fs20 Le terme \\'ab logiciel \\'bb couvre le logiciel et la documentation qui le concerne.\\par\r\nCe logiciel peut-\\'eatre librement distribu\\'e9, \\'e0 condition que :\\par\r\n(a) Cette distribution ne concerne que l'archive d'origine fournie par l'auteur. Vous ne pouvez alt\\'e9rer, supprimer ni ajouter aucun fichier dans l'archive distribu\\'e9e ou modifier ce logiciel d'une quelconque fa\\'e7on.\\par\r\n(b) La personne recevant ce logiciel ne d\\'e9bourse pas d'argent.\\par\r\n\\fs16\\par\r\n\\b\\fs20 Limitation d'utilisation\\b0\\par\r\n\\fs16\\par\r\n\\fs20 LA MODIFICATION DE LA CARTOGRAPHIE OU L'UTILISATION DE CARTOGRAPHIE NON PR\\'c9VUE POUR LA FRANCE EST STRICTEMENT INTERDITE SUR ROUTE. L'UTILISATION DE CE LOGICIEL EST R\\'c9SERV\\'c9 EXCLUSIVEMENT \\'c0 UN USAGE PISTE. \\par\r\n\\fs16\\par\r\n\\b\\fs20 Exclusion de garantie\\b0\\par\r\n\\fs16\\par\r\n\\fs20 CE LOGICIEL EST FOURNI PAR L'AUTEUR \"TEL QUEL\" ET TOUTE GARANTIE EXPLICITE OU IMPLICITE, Y COMPRIS MAIS SANS LIMITATION DE GARANTIE IMPLICITE DE VALEUR MARCHANDE ET D'ADAPTATION \\'c0 UN USAGE PARTICULIER SONT R\\'c9FUT\\'c9S.\\par\r\n\\fs16\\par\r\n\\b\\fs20 Limitation de responsabilit\\'e9\\b0\\par\r\n\\fs16\\par\r\n\\fs20 Ni l'auteur ou quiconque ayant \\'e9t\\'e9 impliqu\\'e9 dans la cr\\'e9ation, la production, ou la livraison du logiciel ne saurait \\'eatre tenu responsable de tous dommages directs ou indirects, cons\\'e9cutifs \\'e0 l'utilisation ou \\'e0 votre incapacit\\'e9 \\'e0 utiliser le logiciel, et cela quand bien m\\'eame l'auteur aurait \\'e9t\\'e9 inform\\'e9 de la possibilit\\'e9 de tels dommages.\\par\r\n\\fs16\\par\r\n\\b\\fs20 Assistance Technique\\b0\\par\r\n\\fs16\\par\r\n\\fs20 Cette licence ne garantie aucune assistance technique ou correction des erreurs du Logiciel TuneECU. L'Utilisateur comprend que le Logiciel TuneECU n'est pas un \"Gratuiciel\" pour lequel vous pouvez en attendre un support technique. Les informations \\'e0 propos de l'utilisation du Logiciel TuneECU sont disponibles depuis le site http://tuneecu.com ou sur les forums r\\'e9f\\'e9renc\\'e9s sur le site.\\f1\\par\r\n}";

	public string strRTF_en = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fswiss\\fprq2\\fcharset0 Tahoma;}{\\f1\\fswiss\\fcharset0 Arial;}}\r\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\b\\f0\\fs20 Software licence agreement\\par\r\n\\fs16\\par\r\n\\b0\\fs20 This is a legal agreement between you, the end user, and the author of the software. Once you install/use TuneECU Software you shall be deemed to have agreed to all terms and conditions described in this document.\\b\\par\r\n\\fs16\\par\r\n\\fs20 Software\\par\r\n\\fs16\\par\r\n\\b0\\fs20 The term \\'ab software \\'bb means the software program and the accompanying documentation.\\par\r\nThis software may be freely distrubuted, provide that :\\par\r\n(a) Such distribution includes only the original archive supplied by the author. You may not alter, delete or add any files in the distribution archive or modify this software in any way.\\par\r\n(b) No money is charged to the person receiving this software.\\b\\par\r\n\\fs16\\par\r\n\\fs20 Disclaimer of Warranties\\par\r\n\\fs16\\par\r\n\\b0\\fs20 THIS SOFTWARE IS PROVIDED BY THE AUTHOR \"AS IS\" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.\\b\\par\r\n\\fs16\\par\r\n\\fs20 Limitation of Liability\\par\r\n\\fs16\\par\r\n\\b0\\fs20 Neither the author, nor anyone else who has been involved in the creation, production or delivery of this product, shall be liable for any direct, indirect, consequential or incidental damages arising out of the use or inability to use the product even if the author have been advised of the possibility of such damages.\\b\\par\r\n\\fs16\\par\r\n\\fs20 User support\\par\r\n\\fs16\\par\r\n\\b0\\fs20 This License does not warrant User support or error correction of the TuneECU Software. User understands the TuneECU software is not a Freeware for which you can expect user support. Information regarding the use of the TuneECU Software are available from the bulletin board system referenced at the TuneECU website http://tuneecu.com.\\f1\\par\r\n}";

	public string strRTF_de = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036\\deflangfe1036{\\fonttbl{\\f0\\fswiss\\fprq2\\fcharset0 Tahoma;}{\\f1\\fswiss\\fprq2\\fcharset0 ArialMT;}}\r\n{\\colortbl ;\\red0\\green0\\blue255;}\r\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\nowidctlpar\\lang1033\\b\\f0\\fs20 Software-Lizenzvereinbarung\\par\r\n\\fs16\\line\\b0\\fs20 Dies ist eine rechtliche Vereinbarung zwischen Ihnen, dem Endanwender, und dem Autor der Software. Nach der Installation / Verwendung der TuneECU Software, gelten f\\'fcr Sie alle Bedingungen die in diesem Dokument beschriebenen wurden, als vereinbart.\\b\\par\r\n\\fs16\\par\r\n\\fs20 Software\\par\r\n\\fs16\\par\r\n\\b0\\fs20 Der Begriff \"Software\" bezeichnet die Software und die dazugeh\\'f6rige Dokumentation.\\line Diese Software kann frei verteilt werden, Voraussetzung:\\par\r\n(a) Sie m\\'fcssen alle Dateien weitergeben, die auch im Originalpaket vom Autor geliefert wurden. Es darf nichts gel\\'f6scht oder hinzugef\\'fcgt werden.\\par\r\n(b) Sie d\\'fcrfen die Software nicht verkaufen oder f\\'fcr die Weitergabe irgendeine Gegenleistung / Geld verlangen. \\b\\par\r\n\\fs16\\par\r\n\\lang1036\\fs20 Gew\\'e4hrleistungsausschluss\\par\r\n\\fs16\\par\r\n\\lang1033\\b0\\fs20 DIE SOFTWARE UND DOKUMENTATION WERDEN SO WIE SIE SIND, OHNE JEDE GARANTIE ANGEBOTEN. DER AUTOR GIBT KEINE AUSDR\\'dcCKLICHEN ODER STILLSCHWEIGENDEN GARANTIEN, EINSCHLIE\\'dfLICH \\'dcBER AUSSEHEN, MARKT\\'dcBLICHKEIT ODER VERWENDBARKEIT F\\'dcR EINE BESTIMMTEN ZWECK.\\par\r\n\\fs16\\par\r\n\\b\\fs20 Haftungsbeschr\\'e4nkung\\par\r\n\\b0\\fs16\\par\r\n\\fs20 Unter keinen Umst\\'e4nden (eingeschlossen Fahrl\\'e4ssigkeit) ist der Autor von TuneECU noch der Webseitenbetreiber, oder jede andere Person die an diesem\\'82 Projekt beteiligt ist, haftbar f\\'fcr Einkommensverlust oder Sch\\'e4den jeglicher Art die durch den Einsatz oder fehlender M\\'f6glichkeit zum Einsatz des Produktes oder der Dokumentation entstehen k\\'f6nnten. \\lang1036 Dies gilt auch, wenn der Autor \\'fcber die M\\'f6glichkeit des Auftretens solcher F\\'e4lle informiert wurde.\\par\r\n\\b\\fs16\\par\r\n\\lang1033\\fs20 User-Unterst\\'fctzung\\par\r\n\\fs16\\par\r\n\\b0\\fs20 Diese Lizenz garantiert keinen Anwendersupport oder Fehlerkorrektur der TuneECU Software.  Dem Benutzer muss klar sein, das TuneECU keine Freeware ist, auf die Anspruch auf User-Support besteht. Informationen zur Verwendung der Software TuneECU sind auf dem Bulletin Board System vorhanden,  Und k\\'f6nnen von der TuneECU Webseite  \\cf1\\ul http://tuneecu.com\\cf0\\ulnone   bezogen werden.\\f1\\par\r\n}";

	public string strRTF_it = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1040{\\fonttbl{\\f0\\fswiss\\fcharset0 Tahoma;}}\r\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\nowidctlpar\\b\\f0\\fs20 Accordo di licenza software\\line\\b0\\fs16\\line\\fs20 Questo \\'e8 un accordo legale tra l'utente finale, e l'autore del software. Una volta installato e/o utilizzato il software TuneECU si considera che se ne siano accettati tutti i termini e le condizioni descritte in questo documento.\\line\\fs16\\line\\b\\fs20 Software\\line\\fs16\\line\\b0\\fs20 Con il termine \\'absoftware\\'bb si intende il software e la documentazione che lo accompagna.\\line Questo software pu\\'f2 essere liberamente distribuito, premesso che:\\line (a) Tale distribuzione includa solo la versione originale fornita dall'autore. L'utente non pu\\'f2 modificare, cancellare o aggiungere qualsiasi file nell'archivio di distribuzione o modificare questo software in alcun modo.\\line (b) nessun esborso di denaro \\'e8 a carico della persona che riceve questo software.\\line\\fs16\\line\\b\\fs20 Esclusione di garanzia\\line\\b0\\fs16\\line\\fs20 QUESTO SOFTWARE VIENE FORNITO dall'autore \"COSI\\rquote  COME E\\rquote \" SENZA ALCUNA GARANZIA ESPLICITA O IMPLICITA, INCLUSE, MA NON SOLO A QUESTE LIMITATE, LE GARANZIE DI COMMERCIABILIT\\'c0 E IDONEIT\\'c0 PER UN PARTICOLARE SCOPO.\\line\\fs16\\line\\b\\fs20 Limitazione di responsabilit\\'e0\\line\\b0\\fs16\\line\\fs20 N\\'e9 l'autore, n\\'e9 nessun altro che \\'e8 stato coinvolto nella creazione, produzione o consegna di questo prodotto, saranno responsabili per eventuali danni diretti, indiretti, incidentali o consequenziali derivanti dall'uso o dall'impossibilit\\'e0 di utilizzare il prodotto anche se l'autore \\'e8 stato informato della possibilit\\'e0 di tali danni.\\line\\fs16\\line\\b\\fs20 Supporto per l'utente\\line\\b0\\fs16\\line\\fs20 La presente Licenza non garantisce alcun supporto per l'utente o la correzione degli errori del Software TuneECU. L\\rquote utente comprende che il software TuneECU \\'e8 un prodotto gratuito per il quale non ci si pu\\'f2 aspettare alcun supporto verso gli utenti. Informazioni riguardanti l'utilizzo del Software TuneECU sono disponibili presso il sito di riferimento TuneECU all\\rquote indirizzo web http://tuneecu.com .\\par\r\n}";

	public string strRTF_es = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang3082\\deflangfe3082{\\fonttbl{\\f0\\fswiss\\fprq2\\fcharset0 Tahoma;}{\\f1\\froman\\fprq2\\fcharset0 Times New Roman;}}\r\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\sa200\\sl276\\slmult1\\b\\f0\\fs20 Licencia de Software\\b0\\line\\fs16\\line\\fs20 Este es un acuerdo legal entre usted, el usuario final, y el autor del software. Una vez que usted instala/usa el software TuneECU se considerar\\'e1 que ha aceptado todos los t\\'e9rminos y condiciones descritos en este documento.\\line\\fs16\\line\\b\\fs20 Software\\b0\\line\\fs16\\line\\fs20 El \\'absoftware\\'bb hace referencia al programa de software y la documentaci\\'f3n adjunta.\\line Este software puede ser libremente distribuido, indica que:\\line (a) Esta distribuci\\'f3n incluye s\\'f3lo el archivo original proporcionado por el autor. No se puede alterar, suprimir o a\\'f1adir archivos en el archivo de distribuci\\'f3n o modificar este software de ninguna manera.\\line (b) No se cobra dinero a la persona que recibe este software.\\line\\fs16\\line\\b\\fs20 Exclusi\\'f3n de garant\\'edas\\b0\\line\\fs16\\line\\fs20 ESTE SOFTWARE ES PROPORCIONADO POR EL AUTOR \"TAL CUAL\", SIN GARANT\\'cdAS EXPRESAS O IMPL\\'cdCITAS, INCLUYENDO, PERO SIN LIMITARSE A ELLAS, LAS GARANT\\'cdAS DE COMERCIALIZACI\\'d3N Y APTITUD PARA UN PROP\\'d3SITO PARTICULAR.\\line\\fs16\\line\\b\\fs20 Limitaci\\'f3n de responsabilidad\\b0\\line\\fs16\\line\\fs20 Ni el autor, ni cualquier otra persona que ha participado en la creaci\\'f3n, producci\\'f3n o entrega de este producto, ser\\'e1 responsable de ning\\'fan da\\'f1o directo, indirecto, incidental o consecuencial que surjan del uso o la imposibilidad de usar el producto, incluso si el autor ha sido advertido de la posibilidad de tales da\\'f1os.\\line\\fs16\\line\\b\\fs20 Asistencia a los usuarios\\b0\\line\\fs16\\line\\fs20 Esta licencia no garantiza asistencia a los usuarios o la correcci\\'f3n de errores del Software TuneECU. El usuario entiende que TuneECU es un software de libre acceso para el que no se puede esperar asistencia al usuario. La informaci\\'f3n sobre el uso del Software TuneECU est\\'e1 disponible en el sistema de tabl\\'f3n de anuncios referenciado en la p\\'e1gina web de TuneECU http://tuneecu.com.\\f1\\fs22\\par\r\n}";

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Warning));
		Ignore = new Button();
		Accept = new Button();
		textBoxDescription = new TextBox();
		licenseTextBox = new RichTextBox();
		((Control)this).SuspendLayout();
		Ignore.DialogResult = (DialogResult)2;
		((Control)Ignore).Location = new Point(460, 432);
		((Control)Ignore).Name = "Ignore";
		((Control)Ignore).Size = new Size(75, 23);
		((Control)Ignore).TabIndex = 0;
		((Control)Ignore).Text = "Refuse";
		((ButtonBase)Ignore).UseVisualStyleBackColor = true;
		Accept.DialogResult = (DialogResult)1;
		((Control)Accept).Location = new Point(318, 432);
		((Control)Accept).Name = "Accept";
		((Control)Accept).Size = new Size(75, 23);
		((Control)Accept).TabIndex = 1;
		((Control)Accept).Text = "Accept";
		((ButtonBase)Accept).UseVisualStyleBackColor = true;
		((Control)textBoxDescription).BackColor = SystemColors.Window;
		((Control)textBoxDescription).Font = new Font("Tahoma", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)textBoxDescription).Location = new Point(14, 14);
		((Control)textBoxDescription).Margin = new Padding(6, 4, 3, 3);
		((TextBoxBase)textBoxDescription).Multiline = true;
		((Control)textBoxDescription).Name = "textBoxDescription";
		((TextBoxBase)textBoxDescription).ReadOnly = true;
		((Control)textBoxDescription).Size = new Size(542, 400);
		((Control)textBoxDescription).TabIndex = 25;
		((Control)textBoxDescription).TabStop = false;
		((Control)textBoxDescription).Text = componentResourceManager.GetString("textBoxDescription.Text");
		textBoxDescription.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)licenseTextBox).BorderStyle = (BorderStyle)0;
		((Control)licenseTextBox).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)licenseTextBox).Location = new Point(15, 15);
		((Control)licenseTextBox).Name = "licenseTextBox";
		((Control)licenseTextBox).Size = new Size(540, 398);
		((Control)licenseTextBox).TabIndex = 26;
		((Control)licenseTextBox).Text = "";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(570, 468);
		((Control)this).Controls.Add((Control)(object)Accept);
		((Control)this).Controls.Add((Control)(object)Ignore);
		((Control)this).Controls.Add((Control)(object)licenseTextBox);
		((Control)this).Controls.Add((Control)(object)textBoxDescription);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Control)this).Name = "Warning";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "TuneECU";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public Warning()
	{
		InitializeComponent();
		switch (ISOMain.mLang)
		{
		case 1:
			licenseTextBox.Rtf = strRTF_fr;
			((Control)Accept).Text = "&Accepter";
			((Control)Ignore).Text = "&Refuser";
			break;
		case 2:
			licenseTextBox.Rtf = strRTF_de;
			((Control)Accept).Text = "&Annehmen";
			((Control)Ignore).Text = "A&blehnen";
			break;
		case 3:
			licenseTextBox.Rtf = strRTF_it;
			((Control)Accept).Text = "&Accettare";
			((Control)Ignore).Text = "&Rifiutare";
			break;
		case 4:
			licenseTextBox.Rtf = strRTF_es;
			((Control)Accept).Text = "&Aceptar";
			((Control)Ignore).Text = "&Rechazar";
			break;
		default:
			licenseTextBox.Rtf = strRTF_en;
			((Control)Accept).Text = "&Accept";
			((Control)Ignore).Text = "&Refuse";
			break;
		}
	}
}
}
