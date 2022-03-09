using ATM_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM_WEB.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ATMWEB Model1)
        {

            List<INS> ILP = new List<INS>();

            string AA;
            AA = Model1.UserATM;
            string[] subs = AA.Split(',');
            string JK;
            string[] IOP = new string[subs.Length];

            int[] Virat = new int[subs.Length];
            int[] Rahul = new int[subs.Length];

            int i, j;
            int YU;

            for (i = 0; i < subs.Length; i++)
            {
                JK = subs[i];
                IOP[i] = JK;
            }

            string UI;
            for (i = 0; i < subs.Length; i++)
            {
                UI = IOP[i];
                string[] sub2 = UI.Split('X');

                for (j = 0; j < sub2.Length; j++)
                {
                    if (j % 2 != 0)
                    {
                        YU = Convert.ToInt32(sub2[j]);
                        Rahul[i] = YU;
                    }
                    else
                    {
                        YU = Convert.ToInt32(sub2[j]);
                        Virat[i] = YU;
                    }
                }
            }


            int n, N, S = 0;
            if (Model1.Bankbankbalance >= Model1.WidrowAmount)
            {
                for (i = 0; i < subs.Length; i++)
                {
                    INS ak = new INS();
                    if (Virat[i] <= Model1.WidrowAmount)
                    {
                        n = Model1.WidrowAmount / Virat[i];
                        if (n <= Rahul[i])
                        {
                            N = Model1.WidrowAmount - Virat[i] * n;
                            ak.ID = i + 1;
                            ak.IR = Rahul[i];
                            ak.IV = Virat[i];
                            ak.IY = n;
                            ak.IS = Virat[i] * n;

                            Rahul[i] = Rahul[i] - n;
                            ak.IRN = Rahul[i];
                            Model1.WidrowAmount = N;

                        }
                        else
                        {
                            N = Model1.WidrowAmount - Virat[i] * Rahul[i];
                            n = Rahul[i];

                            ak.ID = i + 1;
                            ak.IR = Rahul[i];
                            ak.IV = Virat[i];
                            ak.IS = Virat[i] * n;
                            ak.IY = Rahul[i];
                            Rahul[i] = Rahul[i] - n;
                            Model1.WidrowAmount = N;
                        }

                        S += n;
                        ILP.Add(ak);
                    }


                }

                if (Model1.WidrowAmount != 0)
                {
                    ViewBag.Message1 = String.Format($"Your {Model1.WidrowAmount} Amount was remaning?");
                }

            }
            else
            {
                ViewBag.Message = String.Format("Your Withdrawal Amount is Not Valid..!");
            }
            Model1.IN = S;
            Model1.YUIOP = ILP;
            return View(Model1);
        }

    }
}