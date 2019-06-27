using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequenceSolution
{
    public class JobSequence
    {
        private Dictionary<string, JobDependent> jobdata = new Dictionary<string, JobDependent>();
        private class JobDependent
        {
            public int Dependencies = 0;
            public List<string> Dependents = new List<string>();
        }      
        /// <summary>
        /// Add the given job in Dictionary and align with the dependent jobs
        /// </summary>
        /// <param name="job"></param>
        /// <param name="depjob"></param>
        public void Add(string job, string depjob)
        {
            if (depjob.Equals(job)) return;

            if (!jobdata.ContainsKey(depjob)) jobdata.Add(depjob, new JobDependent());

            var dependents = jobdata[depjob].Dependents;

            if (!dependents.Contains(job))
            {
                dependents.Add(job);

                if (!jobdata.ContainsKey(job)) jobdata.Add(job, new JobDependent());

                ++jobdata[job].Dependencies;
            }
        }
        /// <summary>
        /// sort the job based on the dependencies
        /// </summary>
        /// <returns></returns>
        public List<string> Sortjob()
        {
            List<string> sequenced = new List<string>();
            List<string> cyclic = new List<string>();

            var map = jobdata.ToDictionary(x => x.Key, x => x.Value);

            //add sequence element with no dependencies
            sequenced.AddRange(map.Where(x => x.Value.Dependencies == 0).Select(x => x.Key));

            for (int idx = 0; idx < sequenced.Count; ++idx)
            {
                // loop the map item and arrange it according to the sequential order
                sequenced.AddRange(map[sequenced[idx]].Dependents.Where(k => --map[k].Dependencies == 0));
            }
            // add if there is any cyclic dependency
            cyclic.AddRange(map.Where(x => x.Value.Dependencies != 0).Select(x => x.Key));
            if (cyclic.Any())
            {
                throw new Exception(Constant.CircularDependencies);
            }
            return sequenced;
        }


    }
}
