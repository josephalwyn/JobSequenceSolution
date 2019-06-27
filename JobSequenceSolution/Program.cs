using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequenceSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter number of job structure");
                int jobcount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter {0} job structure each in 1 line", jobcount);
                Console.WriteLine("(Ex: if job 'a' depends on job 'b' then enter as a=>b. if job 'a' doesn't depends on any job simply enter a=>)");
                List<string> ls = new List<string>();

                for (int i = 0; i < jobcount; i++)
                {
                    // loop through for given input and add in a list
                    ls.Add(Console.ReadLine());
                }

                Console.WriteLine(OrderSequence(ls));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// To get the order of the job based on the given dependency condition
        /// </summary>
        /// <param name="job">List of string </param>
        /// <returns>string in the order of sequence</returns>
        public static string OrderSequence(List<string> job)
        {

            List<string> ordered = new List<string>();
            string[] stringseparator = new string[] { "=>" };
            JobSequence ts = new JobSequence();
            if (job != null && job.Count > 0)
            {
                foreach (var item in job)
                {
                    // split the given string by seperator and fetcht the parent and the dependent job name
                    var jobs = item.Split(stringseparator, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                    if (jobs.Length > 1)
                    {
                        // if the parent and the dependent job are same thow exception
                        if (jobs[1] == jobs[0])
                        {
                            throw new Exception(Constant.SelfDependencies);
                        }
                        // else do sequencing
                        ts.Add(jobs[0], jobs[1]);
                    }
                    else
                    {
                        // if job doesnt have any dependency make it as empty
                        ts.Add(jobs[0], "");
                    }
                }

                return string.Join(",", ts.Sortjob().Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
