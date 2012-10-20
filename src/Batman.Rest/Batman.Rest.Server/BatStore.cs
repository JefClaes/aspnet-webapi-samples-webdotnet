using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batman.Rest.Server
{
    public class BatStore
    {
        private static List<BatResource> _resources = new List<BatResource>()
        {
            new BatResource("1", "Batarang", 1),
            new BatResource("2", "Grappling hook", 2)
        };

        public IEnumerable<BatResource> GetAll()
        {
            return _resources;
        }

        public BatResource GetById(string id)
        {
            return _resources.Where(r => r.Id == id).FirstOrDefault();
        }       

        public void Add(BatResource batResource)
        {
            _resources.Add(batResource);
        }

        public bool Update(string id, BatResource batResource)
        {
            int index = _resources.FindIndex(r => r.Id == batResource.Id);
            if (index == -1)
                return false;

            _resources.RemoveAt(index);
            _resources.Add(batResource);

            return true;
        }

        public void Delete(string id)
        {
            _resources.RemoveAll(r => r.Id == id);
        }
    }
}
