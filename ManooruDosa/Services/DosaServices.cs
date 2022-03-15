using ManooruDosa.Models;

namespace ManooruDosa.Services;

public static class DosaService {
    static List<Dosa> Dosas {get;}
    static int nextId = 3;
    static DosaService()
    {
        Dosas = new List<Dosa>
        {
            new Dosa {Id=1,Name="Classic SouthIndian",IsGheeFree=false},
            new Dosa {Id=2,Name="Masala Dosa", IsGheeFree=true}
        };

    }

    public static List<Dosa> GetAll() => Dosas;
    public static Dosa? Get(int id) => Dosas.FirstOrDefault<Dosa>(d=> d.Id == id);
    public static void Add(Dosa dosa)
    {
        dosa.Id = nextId++;
        Dosas.Add(dosa);
    }

    public static void Delete(int id)
    {
        var dosa = Get(id);
        if(dosa is null) return;
        Dosas.Remove(dosa);
    }

    public static void Update(Dosa dosa)
    {
        var index = Dosas.FindIndex(d => d.Id == dosa.Id);
        if(index == -1) return;
        Dosas[index] = dosa;
    }
}