# AstroPic

One of the most popular websites at NASA is the Astronomy Picture of the Day. In fact, this website is one of the most popular websites across all federal agencies. It has the popular appeal of a Justin Bieber video. This endpoint structures the APOD imagery and associated metadata so that it can be repurposed for other applications. In addition, if the concept_tags parameter is set to True, then keywords derived from the image explanation are returned. These keywords could be used as auto-generated hashtags for twitter or instagram feeds; but generally help with discoverability of relevant imagery.


AstroPic is a desktop application designed to bring the wonders of space closer to users by leveraging NASA's Astronomy Picture of the Day (APOD) API. The application fetches daily astronomical images and their associated data, presenting this information in an engaging and user-friendly interface. It is used by pressing the "Run" button, and will generate an image with description, copyright and other attributes. 

Technically, AstroPic is developed using C# with the .NET Framework or .NET Core. For the GUI i have used Microsoft Forms. It integrates with NASA's APOD API to fetch images and related information. The development environment used is Visual Studio, with dependencies including JSON libraries for parsing API responses (e.g., Newtonsoft.Json) and web libraries for handling HTTP requests (e.g., HttpClient).

The implementation involves several steps. First, API integration is handled by implementing methods to send HTTP requests to the NASA APOD API and parsing the JSON responses to extract relevant information. The user interface is then designed, including a main window to display the daily image and its details, navigation controls for browsing previous images, and a settings window for user preferences. Data management includes storing user preferences and favorite images locally and implementing caching mechanisms to reduce redundant API calls and improve performance.

The project milestones include setting up the development environment and initial API integration, developing the user interface, adding interactive and customization features, conducting thorough testing and optimization, and performing a final review before deployment.

AstroPic aims to make astronomy more accessible and engaging by providing stunning daily images of the cosmos along with educational information, fostering a deeper appreciation for astronomy and science.

The packages which are essential are already in the repository, but i would recommend downloading Nuget for further installations. 
