using UnityEngine;
using System.Collections;

public class Donate : MonoBehaviour {

	public void DonateNow(){
		Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=PMMQ5SNKDYEC8&lc=US&item_name=Funding%20for%20future%20apps&item_number=8556&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
	}
}
