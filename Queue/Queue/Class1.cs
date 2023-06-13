using System;
namespace Queue
{
    namespace ClacQueue
    {
        public  class MmQueue
        {
            #region init var
            double lam, meu, rou;
            #endregion
            #region CalcQueue
            public void CalcMm1(ref double p0, ref double pn, ref double ls, ref double lq, ref double ws, ref double wq, int s, int n)
            {
                p0 = 1 - rou;
                pn = Math.Pow(rou, n) * p0;
                ls = lam / (meu - lam);
                lq = Math.Pow(lam, 2) / (meu * (meu - lam));
                ws = 1 / (meu - lam);
                wq = lam / (meu * (meu - lam));
            }
            public void CalcMms(ref double p0, ref double pn, ref double ls, ref double lq, ref double ws, ref double wq, int s, int n)
            {
                if (rou != 1)
                {
                    p0 = Math.Pow(sum(s, rou) + (Math.Pow(s * rou, s) / (nFactor(s) * (1 - rou))), -1);
                    if (n < s)
                    {
                        pn = Math.Pow(lam, n) * p0 / (nFactor(n) * Math.Pow(meu, n));
                    }
                    else if (n >= s)
                    {
                        pn = Math.Pow(lam, n) * p0 / (Math.Pow(s, n - s) * nFactor(s) * Math.Pow(meu, n));
                    }

                    lq = p0 * Math.Pow(s * rou, s) * rou / (nFactor(s) * Math.Pow(1 - rou, 2));
                    ls = lq + (s * rou);
                    ws = ls / lam;
                    wq = lq / lam;
                }
                else
                {
                    //MessageBox.Show("rou must not be equal to one ");
                }
            }
            public void CalcMmInf(ref double p0, ref double pn, ref double ls, ref double lq, ref double ws, ref double wq, int s, int n)
            {
                p0 = Math.Pow(Math.Exp(1), -rou);//Math.Exp(-rou);
                pn = Math.Pow(rou, n) * p0 / nFactor(n);
                ls = rou;
                lq = 0;
                ws = 1 / meu;
                wq = 0;
            }
            public void CalcMm1k(ref double p0, ref double pn, ref double ls, ref double lq, ref double ws, ref double wq, int s, int n, int k)
            {
                p0 = (1 - rou) / (1 - Math.Pow(rou, 1 + k));
                pn = Math.Pow(rou, n) * p0;
                ls = (rou / (1 - rou)) - ((k + 1) * Math.Pow(rou, k + 1) / (1 - Math.Pow(rou, k + 1)));
                lq = ls - (1 - p0);
                ws = ls / (lam * (1 - Math.Pow(rou, k) * p0));
                wq = lq / (lam * (1 - Math.Pow(rou, k) * p0));
            }
            #endregion
            #region math_calcuation
            public int nFactor(int f)
            {
                int res = 1;
                for (int i = f; i >= 1; i--)
                {
                    res = res * i;
                }
                return res;
            }
            public double sum(int s, double rou)
            {
                double res = 0;
                for (int i = 0; i < s; i++)
                {
                    res = res + (Math.Pow(s * rou, i) / nFactor(i));
                }
                return res;
            }
            #endregion
            #region  RouCalc
            public void RouCalc(ref double rou, double lam, double meu, int s)
            {
                try
                {
                    if (meu > 0 && lam >= 0 && lam <= meu)
                    {
                        rou = lam / (s * meu);
                        this.rou = rou;
                        this.lam = lam;
                        this.meu = meu;
                    }
                    else
                    {
                        //MessageBox.Show("ERROR");
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("ERROR");
                }
            }
            #endregion
        }
    }
}
