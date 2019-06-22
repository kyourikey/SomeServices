using System;

[Serializable]
public class Card
{
    public string name;
    public string manaCost;
    public float cmc;
    public string[] colors;
    public string[] colorIdentity;
    public string type;
    public string[] supertypes;
    public string[] types;
    public string[] subtypes;
    public string rarity;
    public string set;
    public string setName;
    public string text;
    public string artist;
    public string number;
    public string power;
    public string toughness;
    public string layout;
    public int multiverseid;
    public string imageUrl;
    public string[] variations;
    public Ruling[] rulings;
    public Foreignname[] foreignNames;
    public string[] printings;
    public string originalText;
    public string originalType;
    public Legality[] legalities;
    public string id;
    public string flavor;
    public object[] names;
}
