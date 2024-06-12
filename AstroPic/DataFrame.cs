
using Microsoft.Data.Analysis;
using Newtonsoft.Json.Linq;
namespace NasaApodProject;
//This file is for creating and returning the DataFrame

public class Dataframe
{
    public DataFrame GetDataFrames(JArray jsonArray)
    {
        var copyright = new StringDataFrameColumn("Copyright");
        var date = new StringDataFrameColumn("Date");
        var title = new StringDataFrameColumn("Title");
        var explanation = new StringDataFrameColumn("Explanation");
        var hdurl = new StringDataFrameColumn("HdUrl");
        var mediaType = new StringDataFrameColumn("MediaType");
        var serviceVersion = new StringDataFrameColumn("ServiceVersion");
        var url = new StringDataFrameColumn("Url");

        // Populate DataFrame with API data
        foreach (var item in jsonArray)
        {
            var nasaApod = item.ToObject<NasaApod>();
            if (nasaApod != null)
            {
                copyright.Append(nasaApod.Copyright ?? "");
                date.Append(nasaApod.Date ?? "");
                title.Append(nasaApod.Title ?? "");
                explanation.Append(nasaApod.Explanation ?? "");
                hdurl.Append(nasaApod.HdUrl ?? "");
                mediaType.Append(nasaApod.MediaType ?? "");
                serviceVersion.Append(nasaApod.ServiceVersion ?? "");
                url.Append(nasaApod.Url ?? "");
            }
        }

        // Create and return the DataFrame
        return new DataFrame(copyright, date, title, explanation, hdurl, mediaType, serviceVersion, url);
    }
}