using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
struct Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Gener { get; set; }
    public List<string> NamesOfMember { get; set; }
    [JsonIgnore]
    public string ArtistInfo { get; }

    [JsonConstructor]
    public Artist(int Id, string Name, string Bio, string Gener, List<string> NamesOfMember)
    {
        this.Id = Id;
        this.Name = Name;
        this.Bio = Bio;
        this.Gener = Gener;
        this.NamesOfMember = NamesOfMember;

        this.ArtistInfo = $"Artist ID: {Id}\nArtist Name: {Name}\nArtist Bio: {Bio}\nArtist Gener: {Gener}\n";
        if (NamesOfMember.Count != 0) { ArtistInfo += "Artist Members :\n"; }
        for (int i = 0; i < NamesOfMember.Count; i++)
        {
            this.ArtistInfo += $"    {i + 1} -> {NamesOfMember[i]}\n";
        }
    }
}
struct Album
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Gener { get; set; }
    public int songcount { get; set; }
    public int Releaseyears { get; set; }
    public string Artistname { get; set; }
    [JsonIgnore]
    public string Albuuminfo { get; }

    [JsonConstructor]
    public Album(int ID, string Name, string Description, string Gener, int Releaseyears, string Artistname, int songcount)
    {
        this.ID = ID;
        this.Name = Name;
        this.Description = Description;
        this.Gener = Gener;
        this.songcount = songcount;
        this.Releaseyears = Releaseyears;
        this.Artistname = Artistname;
        this.Albuuminfo = $"Album ID: {ID}\nAlbum Name: {Name}\nAlbum Discription: {Description}\nAlbum Gener: {Gener}\nAlbum songs number: {songcount}\nAlbum Release Year: {Releaseyears}\nAlbum Artist Name: {Artistname}\n";
    }
}
class Song
{
    public int ID { get; set; }
    public string title { get; set; }
    public Artist artist { get; set; }
    public Album album { get; set; }
    public string Gener { get; set; }
    public TimeSpan Duration { get; set; }
    public int year { get; set; }
    public DateTime cratedat { get; set; }
    [JsonIgnore]
    public string songinfo { get; }

    [JsonConstructor]
    public Song(int ID, string title, Artist artist, Album album, string Gener, TimeSpan Duration, int year, DateTime cratedat)
    {
        this.ID = ID;
        this.title = title;
        this.artist = artist;
        this.album = album;
        this.Gener = Gener;
        this.Duration = Duration;
        this.year = year;
        this.cratedat = cratedat;
        this.songinfo = $"song id: {ID}\nsong title: {title}\nsong artist: {artist.Name}\nsong album: {album.Name}\nsong gener: {Gener}\nsong length: {Duration}\nsong relase time: {year}\nsong created: {cratedat}";
    }
    public void EditSongInfo(string title, string artistName, string albumName, string genre, TimeSpan duration, int year)
    {
        int Nid = ID, Ntime = (int)Duration.TotalSeconds, Nyear = this.year;
        Artist Nart = artist;
        Album Nalb = album;
        string Ntitl = this.title, Ngener = Gener;

        if (title != "") { Ntitl = title; }

        if (artistName != "")
        {
            foreach (Artist i in Archive.artists)
            {
                if (i.Name == artistName)
                {
                    Nart = i;
                }
            }
        }

        if (albumName != "")
        {
            foreach (Album i in Archive.albums)
            {
                if (i.Name == albumName)
                {
                    Nalb = i;
                }
            }
        }

        if (genre != "") { Ngener = genre; }
        if (duration.TotalSeconds != 0) { Ntime = (int)duration.TotalSeconds; }
        if (year != -1) { Nyear = year; }

        Archive.songs.Add(new Song(Nid, Ntitl, Nart, Nalb, Ngener, new TimeSpan(0, 0, Ntime), Nyear, cratedat));

    }
    public void play()
    {

        for (int i = 0; i <= 10; i++)
        {
            string sharp = "";
            for (int j = 0; j < i; j++)
            {
                sharp += "#";
            }
            for (int j = i; j < 10; j++)
            {
                sharp += "_";
            }
            Console.Write($"\r{title}: [{sharp}]");
            if (i == 10) { break; }
            Thread.Sleep((int)Duration.TotalSeconds * 100);
        }
        Console.WriteLine("\n");
    }

}
class Playlist
{
    public int id { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public List<Song> songes { get; set; }
    public List<Album> albums { get; set; }
    public string commongener { get; set; }
    public double avgduration { get; set; }
    public DateTime createdat { get; set; }
    [JsonIgnore]
    public string playlistinfo { get; }

    [JsonConstructor]
    public Playlist(int id, string name, string Description, List<Song> songes, List<Album> albums, DateTime createdat)
    {
        this.id = id;
        this.name = name;
        this.Description = Description;
        this.songes = songes;
        this.albums = albums;

        this.commongener = Playlist.com(songes, albums);

        int acg = 0;
        foreach (Song i in songes)
        {
            acg += (int)i.Duration.TotalSeconds;
        }
        this.avgduration = 0;
        if (songes.Count != 0) { this.avgduration = acg / songes.Count; }


        this.createdat = createdat;
        this.playlistinfo = $"Playlist ID: {id}\nPlaylist Name: {name}\nDescription: {Description}\nCommon Gener: {commongener}\nAverage Playlist Time: {avgduration} second\nPlay List Created at: {createdat}\n";
        if (songes.Count != 0) { this.playlistinfo += "  Songes :\n"; }
        for (int i = 0; i < songes.Count; i++)
        {
            this.playlistinfo += $"    {i + 1}->{songes[i].title}\n";
        }
        if (albums.Count != 0) { this.playlistinfo += "  Albumes:\n"; }
        for (int i = 0; i < albums.Count; i++)
        {
            this.playlistinfo += $"    {i + 1}->{albums[i].Name}\n";
        }

    }
    public Song Findsong(int songId)
    {
        foreach (Song i in songes)
        {
            if (i.ID == songId) { return i; }
        }
        Console.WriteLine("song not found");
        return new Song(-1, "", new Artist(), new Album(), "", new TimeSpan(0, 0, 0), 0, new DateTime());
    }
    public void Listsongs()
    {
        if (songes.Count == 0) { Console.WriteLine("not any song"); return; }
        foreach (Song i in songes)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.songinfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public void ListAlbums()
    {
        if (albums.Count == 0) { Console.WriteLine("not any album"); return; }
        foreach (Album i in albums)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.Albuuminfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public void Addsong(int songid)
    {
        foreach (Song i in Archive.songs)
        {
            if (i.ID == songid)
            {
                songes.Add(i); Console.WriteLine("added !"); return;
            }
        }
        Console.WriteLine("your song not found !!!");
    }
    public void Addalbum(int albid)
    {
        foreach (Album i in Archive.albums)
        {
            if (i.ID == albid)
            {
                albums.Add(i); Console.WriteLine("added !"); return;
            }
        }
        Console.WriteLine("your album not found !!!");
    }
    public void removesong(int songid)
    {
        for (int i = 0; i < songes.Count; i++)
        {
            if (songes[i].ID == songid) { songes.Remove(songes[i]); Console.WriteLine("removed"); return; }
        }
        Console.WriteLine($"song with id:{songid} not found");
    }
    public void Playsong()
    {
        foreach (Song i in songes)
        {
            i.play();
        }
    }
    public void playalbum()
    {
        while (true)
        {
            Console.WriteLine("enter id of album");
            int id = 0;
            try { id = int.Parse(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            bool a = true;
            foreach (Album i in albums)
            {
                if (i.ID == id)
                {
                    a = false;
                    if (i.songcount == 0) { Console.WriteLine("this album not have ant song"); break; }
                    foreach (Song j in Archive.songs)
                    {
                        if (j.album.Name == i.Name)
                        {
                            j.play();
                        }
                    }
                }
            }
            if (a) { Console.WriteLine("album not found"); }
            break;
        }
    }
    public void Filtersongby(string title, string gener, int durationmin, int durarionmax, string artistname, string albumname, int yearmin, int yearmax)
    {
        List<int> rep = new List<int>();
        int a = 0;
        if (title == "") { a++; }
        if (gener == "") { a++; }
        if (artistname == "") { a++; }
        if (albumname == "") { a++; }

        for (int k = 4 - a; k >= 0; k--)
        {
            foreach (Song i in songes)
            {
                bool flag = false;
                foreach (int j in rep) { if (j == i.ID) { flag = true; break; } }
                if (flag) { continue; }
                int b = 0;
                if (i.year < yearmin || i.year > yearmax || i.Duration.TotalSeconds < durationmin || i.Duration.TotalSeconds > durarionmax) { continue; }

                if (title != "") { if (i.title == title) { b++; } }
                if (gener != "") { if (i.Gener == gener) { b++; } }
                if (artistname != "") { if (i.artist.Name == artistname) { b++; } }
                if (albumname != "") { if (i.album.Name == albumname) { b++; } }

                if (b >= k) { Console.WriteLine("+++++++++++++++++++++++++++++++++\n" + i.songinfo); rep.Add(i.ID); }
            }
        }
    }
    public static string com(List<Song> a, List<Album> b)
    {
        List<string> total = new List<string>();
        foreach (Song i in a)
        {
            total.Add(i.Gener);
        }
        foreach (Album i in b)
        {
            total.Add(i.Gener);
        }
        List<string> x = total;
        List<int> num = new List<int>();
        for (int i = 0; i < x.Count; i++)
        {
            num.Add(0);
        }
        for (int i = 0; i < x.Count; i++)
        {
            for (int j = 0; j < total.Count; j++)
            {
                if (x[i] == total[j])
                {
                    num[j]++;
                    break;
                }
            }
        }
        int bigest = 0;
        foreach (int i in num)
        {
            if (i > bigest)
            {
                bigest = i;
            }
        }
        for (int i = 0; i < num.Count; i++)
        {
            if (num[i] == bigest)
            {
                return total[i];
            }
        }
        return "";
    }
}
class Archive
{
    public static string usersname { get; set; }
    public static List<Artist> artists { get; set; }
    public static List<Album> albums { get; set; }
    public static List<Song> songs { get; set; }
    public static List<Playlist> playlists { get; set; }
    public Archive()
    {
        usersname ="j";
        artists = new List<Artist>();
        albums = new List<Album>();
        songs = new List<Song>();
        playlists = new List<Playlist>();
    }
    public static Song FindSong(int songID)
    {
        foreach (Song i in songs)
        {
            if (i.ID == songID) { return i; }
        }
        Console.WriteLine("song not found");
        return new Song(-1, "", new Artist(), new Album(), "", new TimeSpan(0, 0, 0), 0, new DateTime());
    }
    public static Playlist FindPlaylist(int playlistID)
    {
        foreach (Playlist i in playlists)
        {
            if (i.id == playlistID) { return i; }
        }
        Console.WriteLine("Play list not found");
        return new Playlist(-1, "", "", new List<Song>(), new List<Album>(), new DateTime());
    }
    public static void addsong()
    {
        if (artists.Count == 0) { Console.WriteLine("we not have any artist to add song"); return; }
        if (albums.Count == 0) { Console.WriteLine("we not have any album to add song"); return; }
        while (true)
        {
            int id = artists.Count + albums.Count + songs.Count + playlists.Count + 1;

            Console.WriteLine("enter a title for new song");
            string title = Console.ReadLine();
            if (title == "") { Console.WriteLine("title can't be null"); continue; }

            Console.WriteLine("enter an artist name for new song");
            string artist = Console.ReadLine();
            if (artist == "") { Console.WriteLine("title can't be null"); continue; }

            Artist newart = new Artist();
            for (int i = 0; i < artists.Count; i++)
            {
                if (artist == artists[i].Name) { newart = artists[i]; }
            }
            if (newart.Name == null) { Console.WriteLine("Artist not found try again"); continue; }

            Console.WriteLine("enter an Album name for new song");
            string album = Console.ReadLine();
            if (album == "") { Console.WriteLine("title can't be null"); continue; }
            Album newalb = new Album();
            for (int i = 0; i < albums.Count; i++)
            {
                if (album == albums[i].Name)
                {
                    albums.Add(new Album(albums[i].ID, albums[i].Name, albums[i].Description, albums[i].Gener, albums[i].Releaseyears, albums[i].Artistname, albums[i].songcount + 1));
                    newalb = new Album(albums[i].ID, albums[i].Name, albums[i].Description, albums[i].Gener, albums[i].Releaseyears, albums[i].Artistname, albums[i].songcount + 1);
                    albums.Remove(albums[i]);
                    break;
                }
            }
            if (newalb.Name == null) { Console.WriteLine("Albumm not found try again"); continue; }

            Console.WriteLine("enter a gener for new song");
            string gener = Console.ReadLine();
            if (gener == "") { Console.WriteLine("gener can't be empty"); continue; }

            Console.WriteLine("enter time of song(second)");
            int time = 0;
            try { time = int.Parse(Console.ReadLine()); if (time < 1) { Console.WriteLine("time cant be negetive"); continue; } }
            catch { Console.WriteLine("wrong format for time of song"); }

            Console.WriteLine("enter song's release  year");
            int year = 0;
            try { year = int.Parse(Console.ReadLine()); if (year < 0) { Console.WriteLine("year can,t be negative"); continue; } }
            catch { Console.WriteLine("wrong format for year"); continue; }
            songs.Add(new Song(id, title, newart, newalb, gener, new TimeSpan(0, 0, time), year, DateTime.Now));
            Console.WriteLine("song added sussesfully");
            break;
        }
    }
    public static void addplaylist()
    {
        while (true)
        {
            int id = artists.Count + albums.Count + songs.Count + playlists.Count + 1;

            Console.WriteLine("enter a name for new playlist");
            string name = Console.ReadLine();
            if (name == "") { Console.WriteLine("name cant be empty"); continue; }

            Console.WriteLine("enter Description for new playlist");
            string des = Console.ReadLine();
            if (des == "") { Console.WriteLine("Description cant be emoty"); continue; }

            playlists.Add(new Playlist(id, name, des, new List<Song>(), new List<Album>(), DateTime.Now));
            Console.WriteLine("play list added complitly");
            break;
        }
    }
    public static void addalbum()
    {
        if (artists.Count == 0) { Console.WriteLine("you dont havea any artist to do this album"); return; }
        while (true)
        {
            int id = artists.Count + albums.Count + songs.Count + playlists.Count + 1;
            Console.WriteLine("enter a name for new Album");
            string name = Console.ReadLine();
            if (name == "") { Console.WriteLine("entery cant be null try again"); continue; }
            Console.WriteLine("enter description for new Album");
            string description = Console.ReadLine();
            if (description == "") { Console.WriteLine("entery cant be null try again"); continue; }
            Console.WriteLine("enter gener for new Album");
            string gener = Console.ReadLine();
            if (gener == "") { Console.WriteLine("entery cant be null try again"); continue; }
            Console.WriteLine("enter the Album's year of release ");
            int year = 0;
            try
            {
                year = int.Parse(Console.ReadLine());
                if (year < 0) { throw new Exception(); }
            }
            catch { Console.WriteLine("release year wrong"); continue; }
            string artname;
            while (true)
            {
                Console.WriteLine("enter an artist name for new Album");
                artname = Console.ReadLine();
                foreach (Artist i in artists)
                {
                    if (i.Name == artname) { albums.Add(new Album(id, name, description, gener, year, artname, 0)); Console.WriteLine("Album added sucsesfully"); return; }
                }
                Console.WriteLine("The Artist not found try again");
            }
        }
    }
    public static void addartist()
    {
        while (true)
        {
            int id = artists.Count + albums.Count + songs.Count + playlists.Count + 1;
            Console.WriteLine("enter a name for new Artist");
            string name = Console.ReadLine();
            if (name == "") { Console.WriteLine("entery cant be null try again"); continue; }
            Console.WriteLine("enter bio for new Artist");
            string bio = Console.ReadLine();
            if (bio == "") { Console.WriteLine("entery cant be null try again"); continue; }
            Console.WriteLine("enter gener for new Artist");
            string gener = Console.ReadLine();
            if (gener == "") { Console.WriteLine("entery cant be null try again"); continue; }
            List<string> member = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter a name to add member or cnter '0' to stop adding member");
                string namee = Console.ReadLine();
                if (namee == "0") { break; }
                if (namee == "") { Console.WriteLine("name can't be null try again"); continue; }
                member.Add(namee);
            }
            artists.Add(new Artist(id, name, bio, gener, member));
            Console.WriteLine("Artist added sucsesfully");
            break;
        }
    }
    public static void removesong(int id)
    {
        for (int i = 0; i < songs.Count; i++)
        {
            if (songs[i].ID == id)
            {
                songs.Remove(songs[i]);
                Console.WriteLine("song remove complitly");
                foreach (Album k in albums)
                {
                    if (k.ID == songs[i].album.ID)
                    {
                        albums.Add(new Album(k.ID, k.Name, k.Description, k.Gener, k.Releaseyears, k.Artistname, k.songcount - 1));
                        albums.Remove(k);
                        break;
                    }
                }
                return;
            }
        }
        Console.WriteLine("song not found to remove it");
    }
    public static void FilterSongsBy(string title, string genre, int durationMin, int durationMax, string artistName, string albumName, int yearMin, int yearMax)
    {
        List<int> rep = new List<int>();
        int a = 0;
        if (title == "") { a++; }
        if (genre == "") { a++; }
        if (artistName == "") { a++; }
        if (albumName == "") { a++; }

        for (int k = 4 - a; k >= 0; k--)
        {
            foreach (Song i in songs)
            {
                bool flag = false;
                foreach (int j in rep) { if (j == i.ID) { flag = true; break; } }
                if (flag) { continue; }
                int b = 0;
                if (i.year < yearMin || i.year > yearMax || i.Duration.TotalSeconds < durationMin || i.Duration.TotalSeconds > durationMax) { continue; }

                if (title != "") { if (i.title == title) { b++; } }
                if (genre != "") { if (i.Gener == genre) { b++; } }
                if (artistName != "") { if (i.artist.Name == artistName) { b++; } }
                if (albumName != "") { if (i.album.Name == albumName) { b++; } }

                if (b >= k) { Console.WriteLine("+++++++++++++++++++++++++++++++++\n" + i.songinfo); rep.Add(i.ID); }
            }
        }

    }
    public static void ListSongs()
    {
        if (songs.Count == 0) { Console.WriteLine("not any song"); return; }
        foreach (Song i in songs)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.songinfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public static void ListPlaylist()
    {
        if (playlists.Count == 0) { Console.WriteLine("not any playlist"); return; }
        foreach (Playlist i in playlists)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.playlistinfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public static void ListArtist()
    {
        if (artists.Count == 0) { Console.WriteLine("not any artist"); return; }
        foreach (Artist i in artists)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.ArtistInfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public static void ListAlbum()
    {
        if (albums.Count == 0) { Console.WriteLine("not any album"); return; }
        foreach (Album i in albums)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine(i.Albuuminfo);
            Console.WriteLine($"-------------------------------------------");

        }
    }
    public static void FilterAlbumsByName(string name)
    {
        List<int> re = new List<int>();
        name += " ";
        char[] namee = name.ToCharArray();
        for (int k = namee.Length; k > 0; k--)
        {

            foreach (Album i in albums)
            {

                string artistname = i.Name + " ";
                char[] albname = artistname.ToCharArray();
                int b = 0;
                for (int j = 0; j < k; j++)
                {

                    if (albname[j] == ' ' || namee[j] == ' ') { break; }
                    if (albname[j] == namee[j])
                    {
                        b++;
                    }
                }
                bool sit = false;
                if (b == k)
                {
                    foreach (int s in re)
                    {
                        if (s == i.ID) { sit = true; }
                    }
                    if (sit) { continue; }
                    re.Add(i.ID);
                    Console.WriteLine(i.Albuuminfo);
                }
            }
        }
    }
    public static void FilterArtistsByName(string name)
    {
        List<int> re = new List<int>();
        name += " ";
        char[] namee = name.ToCharArray();
        for (int k = namee.Length; k > 0; k--)
        {

            foreach (Artist i in artists)
            {

                string artistname = i.Name + " ";
                char[] albname = artistname.ToCharArray();
                int b = 0;
                for (int j = 0; j < k; j++)
                {

                    if (albname[j] == ' ' || namee[j] == ' ') { break; }
                    if (albname[j] == namee[j])
                    {
                        b++;
                    }
                }
                bool sit = false;
                if (b == k)
                {
                    foreach (int s in re)
                    {
                        if (s == i.Id) { sit = true; }
                    }
                    if (sit) { continue; }
                    re.Add(i.Id);
                    Console.WriteLine(i.ArtistInfo);
                }
            }
        }
    }
    public void Menu()
    {
        while (true)
        {
            Console.WriteLine($"{usersname}======================================");
            Console.WriteLine("Enter your choose ...");
            Console.WriteLine("1-Add any thing");
            Console.WriteLine("2-Show any thing");
            Console.WriteLine("3-Find song or playlist");
            Console.WriteLine("4-Remove song by id");
            Console.WriteLine("5-Play a playlist");
            Console.WriteLine("6-Filter by name");
            Console.WriteLine("7-Extra FIlter For song");
            Console.WriteLine("8-Edit song");
            Console.WriteLine("9-Work with play list");
            Console.WriteLine("10-Exit");
            int choose = 0;
            try { choose = int.Parse(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.Clear();
            switch (choose)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("choose one option");
                        Console.WriteLine("1-add artist");
                        Console.WriteLine("2-add album");
                        Console.WriteLine("3-add song");
                        Console.WriteLine("4-add playlist");
                        Console.WriteLine("5-add song to playlist");
                        Console.WriteLine("6-add album to play list");
                        int deside = 0;
                        try { deside = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        switch (deside)
                        {
                            case 1:
                                Archive.addartist();
                                break;
                            case 2:
                                Archive.addalbum();
                                break;
                            case 3:
                                Archive.addsong();
                                break;
                            case 4:
                                Archive.addplaylist();
                                break;
                            case 5:
                                if (playlists.Count == 0) { Console.WriteLine("not any playlist"); break; }
                                if (songs.Count == 0) { Console.WriteLine("not any song to add it"); break; }
                                while (true)
                                {
                                    Console.WriteLine("enter a playlist id to add song");
                                    int id = 0;
                                    try { id = int.Parse(Console.ReadLine()); }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    bool exiist = true;
                                    foreach (Playlist i in playlists)
                                    {
                                        if (i.id == id)
                                        {
                                            exiist = false;
                                            while (true)
                                            {
                                                Console.WriteLine("enter song id to add it");
                                                int idd = 0;
                                                try { idd = int.Parse(Console.ReadLine()); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                i.Addsong(idd);
                                                break;
                                            }
                                            playlists.Add(new Playlist(i.id, i.name, i.Description, i.songes, i.albums, i.createdat));
                                            playlists.Remove(i);
                                            break;
                                        }
                                    }
                                    if (exiist) { Console.WriteLine("playlist not found"); }
                                    break;
                                }
                                break;
                            case 6:
                                if (playlists.Count == 0) { Console.WriteLine("not any playlist"); break; }
                                if (albums.Count == 0) { Console.WriteLine("not any album to add it"); break; }
                                while (true)
                                {
                                    Console.WriteLine("enter a playlist id to add album");
                                    int id = 0;
                                    try { id = int.Parse(Console.ReadLine()); }
                                    catch (Exception e) { Console.WriteLine(e.Message); continue; }
                                    bool exiist = true;
                                    foreach (Playlist i in playlists)
                                    {
                                        if (i.id == id)
                                        {
                                            exiist = false;
                                            while (true)
                                            {
                                                Console.WriteLine("enter album id to add it");
                                                int idd = 0;
                                                try { idd = int.Parse(Console.ReadLine()); }
                                                catch (Exception e) { Console.WriteLine(e.Message); continue; }
                                                i.Addalbum(idd);
                                                break;
                                            }
                                            playlists.Add(new Playlist(i.id, i.name, i.Description, i.songes, i.albums, i.createdat));
                                            playlists.Remove(i);
                                            break;
                                        }
                                    }
                                    if (exiist) { Console.WriteLine("playlist not found"); }
                                    break;
                                }
                                break;
                            default:
                                Console.WriteLine("wrong Entry");
                                break;
                        }
                        if (deside > 0 && deside < 7) { break; }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        if (songs.Count == 0 && playlists.Count == 0 && albums.Count == 0 && artists.Count == 0) { Console.WriteLine("we have nothing to show"); break; }
                        Console.WriteLine("choose one option");
                        Console.WriteLine("1-show Artisr");
                        Console.WriteLine("2-show Album");
                        Console.WriteLine("3-show Song");
                        Console.WriteLine("4-show Playlist");
                        Console.WriteLine("5-show all");
                        int deside = 0;
                        try { deside = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        switch (deside)
                        {
                            case 1:
                                Archive.ListArtist();
                                break;
                            case 2:
                                Archive.ListAlbum();
                                break;
                            case 3:
                                Archive.ListSongs();
                                break;
                            case 4:
                                Archive.ListPlaylist();
                                break;
                            case 5:
                                Console.WriteLine("Artists-------------------");
                                Archive.ListArtist();
                                Console.WriteLine("");
                                Console.WriteLine("Albums--------------------");
                                Archive.ListAlbum();
                                Console.WriteLine("");
                                Console.WriteLine("Songs---------------------");
                                Archive.ListSongs();
                                Console.WriteLine("");
                                Console.WriteLine("Play list-----------------");
                                Archive.ListPlaylist();
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("wrong Entry");
                                break;
                        }
                        if (deside > 0 && deside < 6) { break; }
                    }
                    break;
                case 3:
                    if (songs.Count == 0 && playlists.Count == 0) { Console.WriteLine("we dont have any song or play list"); break; }
                    while (true)
                    {
                        int desid = 0;
                        Console.WriteLine("choose one option");
                        Console.WriteLine("1-Find song");
                        Console.WriteLine("2-Find playlist");
                        try { desid = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        switch (desid)
                        {
                            case 1:
                                if (songs.Count == 0) { Console.WriteLine("we dont have any song"); break; }
                                while (true)
                                {
                                    Console.WriteLine("Enter a song id");
                                    int id = 0;
                                    try { id = int.Parse(Console.ReadLine()); }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    if (FindSong(id).ID != -1)
                                    {
                                        Console.WriteLine(FindSong(id).songinfo);
                                    }
                                    break;
                                }
                                break;
                            case 2:
                                if (playlists.Count == 0) { Console.WriteLine("we dont have any play list"); break; }
                                while (true)
                                {
                                    Console.WriteLine("Enter a Playlist id");
                                    int id = 0;
                                    try { id = int.Parse(Console.ReadLine()); }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    if (FindPlaylist(id).id != -1)
                                    {
                                        Console.WriteLine(FindPlaylist(id).playlistinfo);
                                    }
                                    break;
                                }
                                break;
                            default:
                                Console.WriteLine("wrong entry try again");
                                break;
                        }
                        if (desid == 1 || desid == 2) { break; }
                    }
                    break;
                case 4:
                    if (songs.Count == 0) { Console.WriteLine("Not found any song"); break; }
                    while (true)
                    {
                        Console.WriteLine("1-From evrywhere");
                        Console.WriteLine("2-From a playlist");
                        int de = 0;
                        try { de = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        if (de == 1)
                        {
                            int id = 0;
                            Console.WriteLine("Enter song's id");
                            try { id = int.Parse(Console.ReadLine()); }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            removesong(id);
                            for (int i = 0; i < playlists.Count; i++)
                            {
                                for (int j = 0; j < playlists[i].songes.Count; j++)
                                {
                                    if (playlists[i].songes[j].ID == id)
                                    {
                                        playlists[i].removesong(id);
                                        playlists.Add(new Playlist(playlists[i].id, playlists[i].name, playlists[i].Description, playlists[i].songes, playlists[i].albums, playlists[i].createdat));
                                        playlists.Remove(playlists[i]);
                                    }
                                }
                            }
                            break;
                        }
                        else if (de == 2)
                        {
                            while (true)
                            {
                                Console.WriteLine("enter id of playlist");
                                int iid = 0;
                                try { iid = int.Parse(Console.ReadLine()); }
                                catch (Exception e) { Console.WriteLine(e.Message); }
                                bool flag = true;
                                for (int i = 0; i < playlists.Count; i++)
                                {
                                    if (playlists[i].id == iid)
                                    {
                                        flag = false;
                                        while (true)
                                        {
                                            int id = 0;
                                            Console.WriteLine("Enter song's id");
                                            try { id = int.Parse(Console.ReadLine()); }
                                            catch (Exception e) { Console.WriteLine(e.Message); }
                                            playlists[i].removesong(id);
                                            playlists.Add(new Playlist(playlists[i].id, playlists[i].name, playlists[i].Description, playlists[i].songes, playlists[i].albums, playlists[i].createdat));
                                            playlists.Remove(playlists[i]);
                                            break;
                                        }
                                    }
                                    if (flag) { break; }
                                }
                                if (flag) { Console.WriteLine("play list not found"); }
                                break;
                            }
                        }
                        if (de != 1 && de != 2) { Console.WriteLine("wrong entry"); continue; }
                        break;
                    }
                    break;
                case 5:
                    if (playlists.Count == 0) { Console.WriteLine("not have any playlist ):"); break; }
                    while (true)
                    {
                        Console.WriteLine("enter a play list ID to play it");
                        int id = 0;
                        try { id = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        while (true)
                        {
                            Console.WriteLine("choos=");
                            Console.WriteLine("1-play song");
                            Console.WriteLine("2-play album");
                            int s = 0;
                            try { s = int.Parse(Console.ReadLine()); }
                            catch (Exception e) { Console.WriteLine(e.Message); continue; }
                            if (s == 1)
                            {
                                bool flag = true;
                                foreach (Playlist i in playlists)
                                {
                                    if (i.id == id)
                                    {
                                        flag = false;
                                        if (i.songes.Count == 0) { Console.WriteLine("not any song in this playlist"); break; }
                                        i.Playsong();
                                        break;
                                    }
                                }
                                if (flag) { Console.WriteLine("play list not found"); }
                                break;
                            }
                            if (s == 2)
                            {
                                bool flag = true;
                                foreach (Playlist i in playlists)
                                {
                                    if (i.id == id)
                                    {
                                        flag = false;
                                        if (i.albums.Count == 0) { Console.WriteLine("not any album in this playlist"); break; }
                                        i.playalbum();
                                        break;
                                    }
                                }
                                if (flag) { Console.WriteLine("play list not found"); }
                                break;
                            }
                        }
                        break;
                    }
                    break;
                case 6:
                    if (artists.Count == 0 && albums.Count == 0) { Console.WriteLine("not any album or atrist ;/"); break; }
                    while (true)
                    {
                        Console.WriteLine("1-Artist");
                        Console.WriteLine("2-Album");
                        int des = 0;
                        try { des = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        if (des == 1)
                        {
                            if (artists.Count == 0) { Console.WriteLine("not any atrist ;/"); break; }
                            Console.WriteLine("enter name to search");
                            string name = Console.ReadLine();
                            if (name == "") { Console.WriteLine("name cant be empty"); }
                            Archive.FilterArtistsByName(name);
                            break;
                        }
                        else if (des == 2)
                        {
                            if (albums.Count == 0) { Console.WriteLine("not any album ;/"); break; }
                            Console.WriteLine("enter name to search");
                            string name = Console.ReadLine();
                            if (name == "") { Console.WriteLine("name cant be empty"); }
                            Archive.FilterAlbumsByName(name);
                            break;
                        }
                        else { Console.WriteLine("choose right"); continue; }
                    }
                    break;
                case 7:
                    if (songs.Count == 0) { Console.WriteLine("we don't have any song"); break; }
                    Console.WriteLine("enter the asked field(keep field empty to not impact)");
                    string title, gener, artname, albname;
                    int durmin = 0, durmax = 0, yearmin = 0, yearmax = 0;

                    Console.WriteLine("enter title of song");
                    title = Console.ReadLine();

                    Console.WriteLine("enter gener of song");
                    gener = Console.ReadLine();

                    Console.WriteLine("enter artist of song");
                    artname = Console.ReadLine();

                    Console.WriteLine("enter album of song");
                    albname = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("enter minimum size of song(second)");
                        string a = Console.ReadLine();
                        if (a == "") { durmin = 0; break; }
                        try { durmin = int.Parse(a); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("enter maximum size of song(second)");
                        string a = Console.ReadLine();
                        if (a == "") { durmax = 999999999; break; }
                        try { durmax = int.Parse(a); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("enter minimum year release");
                        string a = Console.ReadLine();
                        if (a == "") { yearmin = 0; break; }
                        try { yearmin = int.Parse(a); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("enter maximum year release");
                        string a = Console.ReadLine();
                        if (a == "") { yearmax = 999999999; break; }
                        try { yearmax = int.Parse(a); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;
                    }
                    Archive.FilterSongsBy(title, gener, durmin, durmax, artname, albname, yearmin, yearmax);
                    break;
                case 8:
                    if (songs.Count == 0) { Console.WriteLine("not any song exist"); break; }
                    while (true)
                    {
                        Console.WriteLine("Enter id of song to edit");
                        int id = 0;
                        try { id = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        bool sit = true;
                        foreach (Song i in songs)
                        {
                            if (i.ID == id)
                            {
                                sit = false;
                                Console.WriteLine("enter new title");
                                string titlee = Console.ReadLine();
                                string art, alb;
                                while (true)
                                {
                                    Console.WriteLine("enter new artist name");
                                    art = Console.ReadLine();
                                    bool si = true;
                                    if (art == "") { si = false; break; }
                                    foreach (Artist j in artists)
                                    {
                                        if (j.Name == art) { si = false; }
                                    }
                                    if (si) { Console.WriteLine("Artist not found"); continue; }
                                    break;
                                }
                                while (true)
                                {
                                    Console.WriteLine("enter new album name");
                                    alb = Console.ReadLine();
                                    bool si = true;
                                    if (alb == "") { si = false; break; }
                                    foreach (Album j in albums)
                                    {
                                        if (j.Name == alb) { si = false; }
                                    }
                                    if (si) { Console.WriteLine("Album not found"); continue; }
                                    break;
                                }
                                Console.WriteLine("enter new gener");
                                string genr = Console.ReadLine();
                                int time;
                                while (true)
                                {
                                    Console.WriteLine("enter new time of song(second)");
                                    string t = Console.ReadLine();
                                    time = 0;
                                    if (t == "") { break; }
                                    try { time = int.Parse(t); if (time < 1) { Console.WriteLine("time most be bigger"); continue; } }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    break;
                                }
                                int year;
                                while (true)
                                {
                                    Console.WriteLine("enter new year of releas");
                                    string y = Console.ReadLine();
                                    year = -1;
                                    if (y == "") { break; }
                                    try { year = int.Parse(y); if (year < 0) { Console.WriteLine("year cant be smaller than zero"); continue; } }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    break;
                                }
                                i.EditSongInfo(titlee, art, alb, genr, new TimeSpan(0, 0, time), year);
                                Console.WriteLine("editting sucsesfully");

                                songs.Remove(i);
                                for (int k = 0; k < playlists.Count; k++)
                                {
                                    foreach (Song x in playlists[k].songes)
                                    {
                                        if (x.ID == id)
                                        {
                                            playlists[k].songes.Remove(x);
                                            foreach (Song y in songs)
                                            {
                                                if (y.ID == id)
                                                {
                                                    playlists[k].songes.Add(y);
                                                    playlists.Add(new Playlist(playlists[k].id, playlists[k].name, playlists[k].Description, playlists[k].songes, playlists[k].albums, playlists[k].createdat));
                                                    playlists.Remove(playlists[k]);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        if (sit) { Console.WriteLine("song not found"); }
                        break;
                    }
                    break;
                case 9:
                    if (playlists.Count == 0) { Console.WriteLine("not any play list exist"); break; }
                    while (true)
                    {
                        Console.WriteLine("enter a play list id to work with it");
                        int iD = 0;
                        try { iD = int.Parse(Console.ReadLine()); }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        bool s = true;
                        foreach (Playlist i in playlists)
                        {
                            if (i.id == iD)
                            {
                                s = false;
                                if (i.songes.Count == 0) { Console.WriteLine("This play list no have any song"); break; }
                                while (true)
                                {
                                    Console.WriteLine("Choose...____________");
                                    Console.WriteLine("1-Find song");
                                    Console.WriteLine("2-List of song");
                                    Console.WriteLine("3-List of album");
                                    Console.WriteLine("4-Ultra search");
                                    int chos = 0;
                                    try { chos = int.Parse(Console.ReadLine()); }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    switch (chos)
                                    {
                                        case 1:
                                            while (true)
                                            {
                                                Console.WriteLine("enter an id of song");
                                                int sid = 0;
                                                try { sid = int.Parse(Console.ReadLine()); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                if (i.Findsong(sid).ID != -1)
                                                {
                                                    Console.WriteLine(i.Findsong(sid).songinfo);
                                                }
                                                break;
                                            }
                                            break;
                                        case 2:
                                            i.Listsongs();
                                            break;
                                        case 3:
                                            i.ListAlbums();
                                            break;
                                        case 4:

                                            Console.WriteLine("enter the asked field(keep field empty to not impact)");
                                            string stitle, sgener, sartname, salbname;
                                            int sdurmin = 0, sdurmax = 0, syearmin = 0, syearmax = 0;

                                            Console.WriteLine("enter title of song");
                                            stitle = Console.ReadLine();

                                            Console.WriteLine("enter gener of song");
                                            sgener = Console.ReadLine();

                                            Console.WriteLine("enter artist of song");
                                            sartname = Console.ReadLine();

                                            Console.WriteLine("enter album of song");
                                            salbname = Console.ReadLine();

                                            while (true)
                                            {
                                                Console.WriteLine("enter minimum size of song(second)");
                                                string a = Console.ReadLine();
                                                if (a == "") { sdurmin = 0; break; }
                                                try { sdurmin = int.Parse(a); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                break;
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine("enter maximum size of song(second)");
                                                string a = Console.ReadLine();
                                                if (a == "") { sdurmax = 999999999; break; }
                                                try { sdurmax = int.Parse(a); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                break;
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine("enter minimum year release");
                                                string a = Console.ReadLine();
                                                if (a == "") { syearmin = 0; break; }
                                                try { syearmin = int.Parse(a); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                break;
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine("enter maximum year release");
                                                string a = Console.ReadLine();
                                                if (a == "") { syearmax = 999999999; break; }
                                                try { syearmax = int.Parse(a); }
                                                catch (Exception e) { Console.WriteLine(e.Message); }
                                                break;
                                            }
                                            i.Filtersongby(stitle, sgener, sdurmin, sdurmax, sartname, salbname, syearmin, syearmax);

                                            break;
                                    }
                                    if (chos != 1 && chos != 2 && chos != 3 && chos != 4) { Console.WriteLine("wrong number try again"); continue; }
                                    break;
                                }

                            }
                        }
                        if (s) { Console.WriteLine("play list not found"); }
                        break;
                    }

                    break;
                case 10:
                    Archive.Savefile();
                    return;
                default:
                    Console.WriteLine("wrong entry");
                    break;
            }
        }
    }
    public static void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Save load = JsonSerializer.Deserialize<Save>(json);

            usersname = load.Username;
            artists = load.Artists ?? new List<Artist>();
            albums = load.Albums ?? new List<Album>();
            songs = load.Songs ?? new List<Song>();
            playlists = load.Playlists ?? new List<Playlist>();
        }
        else
        {
            Console.WriteLine("No save file found. Starting fresh.");
        }
    }
    public static void Savefile()
    {
        Save jsons = new Save();
        string J = JsonSerializer.Serialize(jsons, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Archiv.json", J);
    }

}
class Save 
{
    public string Username { get; set; }
    public List<Artist> Artists { get; set; }
    public List<Album> Albums { get; set; }
    public List<Song> Songs { get; set; }
    public List<Playlist> Playlists { get; set; }

    public Save()
    {
        this.Username =Archive.usersname;
        this.Artists = Archive.artists;
        this.Albums = Archive.albums;
        this.Songs = Archive.songs;
        this.Playlists = Archive.playlists;
    }
}

class Pro
{
    static void Main()
    {
        Archive Program = new Archive();
        Archive.LoadFromJson("Archiv.json");
        Program.Menu();
    }
}
//1
//4
//a
//a
//1
//1
//a
//a
//a
//a
//0
//1
//2
//a
//a
//a
//1
//a
//1
//3
//a
//a
//a
//a
//10
//132
//1
//3
//b
//a
//a
//a
//1
//1
//1
//1
//w
//w
//w
//w
//0
//1
//2
//w
//w
//w
//1
//w
//1
//3
//a
//a
//a
//a
//100
//1232
//1
//3
//a
//w
//w
//w
//120
//1999
//1
//3
//q
//a
//w
//a
//200
//1111
//1
//3
//w
//w
//w
//w
//100
//1124
//1
//3
//a
//a
//w
//a
//188
//1978
//1
//3
//a
//a
//w
//a
//1000
//1324
//1
//3
//a
//w
//w
//w
//150
//650
