using Lesson01.Models;

namespace Lesson01.CustemerServices
{
	public class CustemersServices
	{
		private static List<Custemers> _custemers = new List<Custemers>();
		public CustemersServices()
		{
			PopulateData();
		}
		public IEnumerable<Custemers> GetCustemers() => _custemers;
		public Custemers? FindById(int id) => _custemers.FirstOrDefault(x => x.Id == id);	
		public void Create(Custemers custemers) => _custemers.Add(custemers);
		public void Update(Custemers custemersUpdate)
		{
			var custemer = FindById(custemersUpdate.Id);

			if (custemer != null)
			{
				custemer.Name = custemersUpdate.Name;
				custemer.PhoneNumber = custemersUpdate.PhoneNumber;
			}
		}
		public void Delete(int id)
		{
			var cutemer = FindById(id);
			if (cutemer != null)
			{
			_custemers.Remove(cutemer);
			}
		}
		public static void PopulateData()
		{
			if (_custemers.Count > 0)
			{
				return;
			}
			_custemers.Add(new Custemers()
			{
				Id = 1,
				Name = "Davron",
				PhoneNumber = 1342352345
			});
			_custemers.Add(new Custemers()
			{
				Id = 2,
				Name = "Amir",
				PhoneNumber = 134231245
			});
			_custemers.Add(new Custemers()
			{
				Id = 3,
				Name = "Samira",
				PhoneNumber = 134230000
			});
			_custemers.Add(new Custemers()
			{
				Id = 4,
				Name = "Dier",
				PhoneNumber = 1342352345
			});
		}
	}
}
