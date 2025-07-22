using System.Collections.Generic;

public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Properties properties { get; set; }
}

public class Properties
{
    public double mag { get; set; }
    public string place { get; set; }
}
