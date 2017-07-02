using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class main : MonoBehaviour
{

	public Text mText;

	public InputField mInputText;

	public AudioSource unlocked;
	public AudioSource takemeback;
	public AudioSource amsterdam;

	public AudioSource mMorse;

	private int mStep;
	List<string> mTextList;
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector3 currentSwipe;

	private bool SwipeLeft;
	private bool SwipeRight;
	private float swipeTimer;
	private string mInputTxt;
	private float gameTime;
	private bool first;
	private bool mTyping;
	private bool mPrintLocation;
	private bool mGeolocStarting;
	private double mLatitude;
	private double mLongitude;

	// Use this for initialization
	void Start()
	{
		mTyping = false;
		SwipeLeft = false;
		SwipeRight = false;
		mGeolocStarting = false;
		mPrintLocation = false;
		mStep = 0;
		gameTime = 0f;
		mTextList = new List<string>();
		mTextList.Add("Vous vous réveillez avec un étrange mal de crâne...");
		mTextList.Add("Vous avez dû trop boire ou trop dormir...");
		mTextList.Add("Vous ne vous souvenez pas du jour précédent. \nEn réalité, votre dernier souvenir remonte blabla.");
		mTextList.Add("blablabla.");
		mTextList.Add("Pour retrouver vos souvenirs perdus, vous allez devoir récupérer des éléments de votre mémoire, indice après indice, souvenir après souvenir.");
		mTextList.Add("La première clés est le premier repas.");


		mTextList.Add("Toute aventure commence par une bonne préparation! \nPrenez votre petit déjeuner...");


		mTextList.Add("blabla.");
		mTextList.Add("bla.");
		mTextList.Add("blabla ?");
		mTextList.Add("Vous décidez de vous lancer dans cette aventure à la recherche de votre mémoire!");

		mTextList.Add("Tuot nu remrof tuep tubéd euqahc. Tnatropmi sulp el ici tse tubéd el.");


		mTextList.Add("blablabla.");
		mTextList.Add("Ces champs ne sont pas les mêmes, vous allez devoir prendre Joe Dassin à contre pieds pour les montés.");


		mTextList.Add("En arrivant au sommet par l'Est, nostalgique des premiers instants, vous regardez vers le Sud Ouest.");
		mTextList.Add("Le mot le plus haut est l'indice.");


		mTextList.Add("Rendez-vous au lieu du premier saut en parachute de l'histoire, vous y pic-niquerez.");

		mTextList.Add("La tour parisienne vous aidera à déchiffrer!");

		mTextList.Add("KT IK ZKSVY RG, SGJGSK VGORRKXUT GAXGOZ VA BUAY JKSGTJKX JK R'GOJKX.");



		mTextList.Add("Rendez-vous à la place des Abesses pour revivre ces moments..");


		mTextList.Add("blabla");
		mTextList.Add("blablabla");


		mTextList.Add("bla.");
		mTextList.Add("blabla");
		mTextList.Add("blablabla bla.");


		mTextList.Add("bla bla blabla.");
		mTextList.Add("blablabla.");
		mTextList.Add("blibla la clés est blabla.");



		mTextList.Add("Vous commencez à fatiguer. Vous avez bien mérité un petit répis.");
		mTextList.Add("Repassez par l'apparte, où vous pourrez vous préparer pour la soirée.");


		mTextList.Add("blabla");


		mTextList.Add("Vous êtes maintenant rentrée. Vous avez retrouvé toute votre mémoire. blabla?");
		mTextList.Add("Le dernier mot marque la fin.");

		//mInputText.onValueChanged.AddListener(delegate { mInputTxt = mInputText.text; } );
	}

	// Update is called once per frame
	void Update()
	{
		swipeTimer += Time.deltaTime;
		//Swipe management
		if (swipeTimer > 0.4F && !mTyping)
			Swipe();
		if (SwipeRight) {
			if (mStep != 0 && mStep != 6 && mStep != 7 && mStep != 8 && mStep != 9 && mStep != 11 && mStep != 18 && mStep != 19 && mStep != 20 && mStep != 25 && mStep != 28 && mStep != 33 && mStep != 34 && mStep != 41 && mStep != 46) {
				mText.text = "";
				mStep--;
			}
			SwipeRight = false;
			swipeTimer = 0F;
		} else if (SwipeLeft) {
			if (mStep != 6 && mStep != 7 && mStep != 8 && mStep != 10 && mStep != 18 && mStep != 19 && mStep != 22 && mStep != 24 && mStep != 27 && mStep != 29 && mStep != 32 && mStep != 33 && mStep != 40 && mStep != 45) {
				mText.text = "";
				mStep++;
			}
			SwipeLeft = false;
			swipeTimer = 0F;
		}

		// Test pour géoloc
		//if (mStep == 0) {
		//	gameTime += Time.deltaTime;
		//	if (gameTime > 10F) {

		//		if (!mGeolocStarting && Input.location.status != LocationServiceStatus.Running)
		//			StartCoroutine(StartGeoloc());

		//		mText.text = " \n \n" + Input.location.lastData.latitude + " \n" + Input.location.lastData.longitude;
		//		gameTime = 0F;
		//		//if ((Math.Abs(mLatitude - 48.8648986) < 0.01) && (Math.Abs(mLongitude - 2.3558355) < 0.01)) {
		//		//	unlocked.Play();
		//		//	mText.text = "";
		//		//	mStep++;
		//		//}

		//	}
		//} else 
		if (mStep < 6) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[mStep]));
			//mText.text = mTextList[mStep];
		} else if (mStep == 6) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			mStep++;
		} else if (mStep == 7) {
			if (mInputText.text.ToLower() == "petit déjeuner" || mInputText.text.ToLower() == "petit dejeuner") {
				unlocked.Play();
				gameTime = 0F;
				mText.text = "";
				first = true;
				mStep++;
			}

		} else if (mStep == 8) {
			//Prenez votre petit dej
			gameTime += Time.deltaTime;
			if (first) {
				if (mText.text == "")
					StartCoroutine(AnimateText(mTextList[mStep - 2]));
				//mText.text = mTextList[mStep - 2];
				mText.gameObject.SetActive(true);
				mInputText.gameObject.SetActive(false);
				first = false;
			}
			if (gameTime > 75F) {
				mText.gameObject.SetActive(false);
				mStep++;

				first = true;
			}

		} else if (mStep == 9) {
			gameTime += Time.deltaTime;
			if (first) {
				gameTime = 0F;
				mInputText.gameObject.SetActive(false);
				mMorse.Play();
				mInputText.text = "";
				first = false;
			}
			if (gameTime > 47F) {
				mInputText.gameObject.SetActive(true);
				mStep++;
			}


		} else if (mStep == 10) {
			mInputText.gameObject.SetActive(true);
			first = true;
			if (mInputText.text.ToLower() == "pain aux raisins" || mInputText.text.ToLower() == "pain au raisins") {
				mMorse.Stop();
				unlocked.Play();
				mText.text = "";
				StartCoroutine(AnimateText(mTextList[mStep - 3]));
				mText.gameObject.SetActive(true);
				mInputText.gameObject.SetActive(false);
				mInputText.text = "";
				mStep++;
			}
		} else if (mStep < 15) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[mStep - 4]));
		} else if (mStep == 16) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[mStep - 5]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);
		} else if (mStep == 17) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			if (mInputText.text.ToLower() == "tnrttetseitte") {
				unlocked.Play();
				mText.text = "";
				mInputText.text = "";
				mText.gameObject.SetActive(true);
				mInputText.gameObject.SetActive(false);
				StartCoroutine(AnimateText(mTextList[12]));
				gameTime = 0F;
			}



		} else if (mStep == 18) {

			gameTime += Time.deltaTime;
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[13]));

			gameTime += Time.deltaTime;

			if ((mText.text == mTextList[13] || mPrintLocation) && gameTime > 10.0F) {
				mPrintLocation = true;
						if (!mGeolocStarting && Input.location.status != LocationServiceStatus.Running)
							StartCoroutine(StartGeoloc());

			
				gameTime = 0F;
				double lLatitude = mLatitude - 48.8668892;
				double lLongitude = mLongitude - 2.3192452;
				mText.text = mTextList[13] + " \n \n" + lLatitude + " \n" + lLongitude ;
				if ((Math.Abs(mLatitude - 48.8668892) < 0.01) && (Math.Abs(mLongitude - 2.3192452) < 0.01)) {
					unlocked.Play();
					mText.text = "";
					mStep++;
				}
			}

			if ((Math.Abs(Input.location.lastData.latitude - 48.8668892) < 0.01) && (Math.Abs(Input.location.lastData.longitude - 2.3192452) < 0.01)) {
				unlocked.Play();
				mStep++;
			}

		} else if (mStep == 19) {
			gameTime += Time.deltaTime;
			if (gameTime > 10.0F) {
				mText.text = " \n \n" + Input.location.lastData.latitude + " \n" + Input.location.lastData.longitude;
				gameTime = 0F;
			}
			if ((Math.Abs(Input.location.lastData.latitude - 48.8648986) < 0.01) && (Math.Abs(Input.location.lastData.longitude - 2.3580242) < 0.01)) {
				unlocked.Play();
				mText.text = "";
				mStep++;
			}

		} else if (mStep == 20) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[14]));
			mText.gameObject.SetActive(true);

		} else if (mStep == 21) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[15]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

		} else if (mStep == 22) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			if (mInputText.text.ToLower() == "toulouse") {
				unlocked.Play();
				mText.text = "";
				mInputText.text = "";
				mStep++;
			}

		} else if (mStep == 23) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[16]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

			// Parc Monceau
		} else if (mStep == 24) {
			//mText.gameObject.SetActive(false);
			gameTime += Time.deltaTime;
			if (gameTime > 10.0F) {
				mText.text = " \n \n" + Input.location.lastData.latitude + " \n" + Input.location.lastData.longitude;
				gameTime = 0F;
			}
			if ((Math.Abs(Input.location.lastData.latitude - 48.8754711) < 0.01) && (Math.Abs(Input.location.lastData.longitude - 2.3099314) < 0.01)) {
				unlocked.Play();
				mText.text = "";
				mStep++;
			}

		} else if (mStep == 25) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[17]));
			mText.gameObject.SetActive(true);
			Input.location.Stop();

		} else if (mStep == 26) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[18]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);


		} else if (mStep == 27) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			if (mInputText.text.ToLower() == "1834") {
				unlocked.Play();

				mInputText.text = "";
				mStep++;
			}


		} else if (mStep == 28) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[19]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

			StartCoroutine(StartGeoloc());


			// Parc des abesses 48.8848684,2.3363208
		} else if (mStep == 29) {

			if (!mGeolocStarting && Input.location.status != LocationServiceStatus.Running)
				StartCoroutine(StartGeoloc());
			//mText.gameObject.SetActive(false);
			gameTime += Time.deltaTime;
			if (gameTime > 10.0F) {
				mText.text = " \n \n" + Input.location.lastData.latitude + " \n" + Input.location.lastData.longitude;
				gameTime = 0F;
			}
			if ((Math.Abs(Input.location.lastData.latitude - 48.8848684) < 0.01) && (Math.Abs(Input.location.lastData.longitude - 2.3363208) < 0.01)) {
				unlocked.Play();
				mText.text = "";
				mStep++;
			}
		} else if (mStep == 30) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[20]));
			mText.gameObject.SetActive(true);
			//TODO Input.location.Stop();

		} else if (mStep == 31) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[21]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

		} else if (mStep == 32) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			if (mInputText.text.ToLower() == "eg elska pig") {
				unlocked.Play();
				mText.text = "";
				mInputText.text = "";
				mStep++;
			}

		} else if (mStep == 33) {


			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

			//mText.gameObject.SetActive(false);
			gameTime += Time.deltaTime;
			if (gameTime > 5.0F) {
				mText.text = " \n \n" + Input.location.lastData.latitude + " \n" + Input.location.lastData.longitude;
				gameTime = 0F;
			}
			if ((Math.Abs(Input.location.lastData.latitude - 48.8867046) < 0.01) && (Math.Abs(Input.location.lastData.longitude - 2.3431043) < 0.01)) {
				unlocked.Play();
				mText.text = "";
				StartCoroutine(AnimateText(mTextList[mStep - 11]));
			}


		} else if (mStep > 33 && mStep < 39) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[mStep - 11]));

		} else if (mStep == 39) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			mStep++;
		} else if (mStep == 40) {
			if (mInputText.text.ToLower() == "bla bla" || mInputText.text.ToLower() == "blabla") {
				unlocked.Play();
				mText.text = "";
				mInputText.text = "";
				mStep++;
			}
		} else if (mStep == 41) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[28]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);
		} else if (mStep == 42) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[29]));

		} else if (mStep == 43) {
			if (mText.text == "") {
				StartCoroutine(AnimateText(mTextList[30]));
			}

		} else if (mStep == 44) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			mStep++;

		} else if (mStep == 45) {
			if (mInputText.text.ToLower() == "21") {
				unlocked.Play();
				mText.text = "";
				mInputText.text = "";
				mStep++;
			}
		} else if (mStep == 46) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[31]));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);

		} else if (mStep == 47) {
			if (mText.text == "")
				StartCoroutine(AnimateText(mTextList[32]));
		} else if (mStep == 48) {
			mText.gameObject.SetActive(false);
			mInputText.gameObject.SetActive(true);
			mStep++;
		} else if (mStep == 49) {
			if (mInputText.text.ToLower() == "fin" || mInputText.text.ToLower() == "la fin") {

				takemeback.Play();
				mText.text = "";
				mInputText.text = "";
				mStep++;
			}
		} else if (mStep == 50) {
			if (mText.text == "")
				StartCoroutine(AnimateText(""));
			mText.gameObject.SetActive(true);
			mInputText.gameObject.SetActive(false);
		} else if (mStep == 51) {
			if (mText.text == "")
				StartCoroutine(AnimateText("Viens je t'emmène! Swipe pour découvrir où!"));
		} else if (mStep == 52) {
			amsterdam.Play();
		}
	}









	//Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
	IEnumerator AnimateText(string iText, float iSpeed = 0.03F)
	{
		mTyping = true;
		for (int i = 0; i < iText.Length + 1; i++) {
			mText.text = iText.Substring(0, i);
			yield return new WaitForSeconds(iSpeed);
		}
		mTyping = false;
	}




	// Stop service if there is no need to query location updates continuously
	//Input.location.Stop();


	public void Swipe()
	{

		if (Input.GetKey("right")) {
			SwipeLeft = true;
		}


		if (Input.GetKey("left")) {
			SwipeRight = true;
		}

		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began) {
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Ended) {
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x, t.position.y);

				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				//normalize the 2d vector
				currentSwipe.Normalize();

				//swipe upwards
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					Debug.Log("up swipe");
				}
				//swipe down
				if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					Debug.Log("down swipe");
				}
				//swipe left
				if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					SwipeLeft = true;
				}
				//swipe right
				if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					SwipeRight = true;
				}
			}
		}
	}






	IEnumerator StartGeoloc()
	{
		mGeolocStarting = true;
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser) {
			mGeolocStarting = false;
			yield break;
		}

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			print("Timed out");
			//mText.text = "timed out";
			mGeolocStarting = false;
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			//mText.text = "Unable to determine device location";
			mGeolocStarting = false;
			yield break;
		}

		mLatitude = Input.location.lastData.latitude;
		mLongitude = Input.location.lastData.longitude;

		Input.location.Stop();
		mGeolocStarting = false;

	}





}


