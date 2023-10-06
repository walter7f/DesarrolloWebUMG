using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApplication.Core.Model;

namespace AspNetWebApplication.Core.Repositories
{
   public interface IPersonRepository_G5 : IGenericRepository<AlumnosG5>
{
    Alumno_G5 GetByCode(string code);
    void Create(Alumno_G5 alumno_G5);
    IEnumerable<Alumno_G5> Read();
}

internal class PersonRepository_G5 : GenericRepository<AspNetWebApplicationEntities, Alumno_G5>, PersonRepository
{
    public PersonRepository_G5(AspNetWebApplicationEntities ctx) : base(ctx) { }

    public Alumno_G5 GetByCode(string code)
    {
        var dc = Context;
        var data = dc.People
                     .Where(x => x.Code == code)
                     .Select(x => new Alumno_G5
                     {
                         PersonIdG5 = x.PersonId,
                         Code = x.Code,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Sede = x.Phone,
                         Plan = x.Address,
                         Centro_Educativo = x.BloodType,
                         CreationDate = x.CreationDate
                     })
                     .FirstOrDefault();

        return data ?? new Alumno_G5();
    }

    public void Create(Alumno_G5 alumno_G5)
    {
        var dc = Context;
        var newAlumno = new Person
        {
            Code = alumno_G5.Code,
            FirstName = alumno_G5.FirstName,
            LastName = alumno_G5.LastName,
            Phone = alumno_G5.Sede,
            Address = alumno_G5.Plan,
            BloodType = alumno_G5.Centro_Educativo,
            CreationDate = DateTime.Now
        };
        dc.People.Add(newAlumno);
        dc.SaveChanges();
    }
}

public class Alumno_G5
{
    public int PersonIdG5 { get; set; }
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sede { get; set; }
    public string Plan { get; set; }
    public string Centro_Educativo { get; set; }
    public DateTime? CreationDate { get; set; }
}

}
