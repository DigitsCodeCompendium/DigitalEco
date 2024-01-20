using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Nuclear
{
    static class RankineData
    {
        private static float QuarticFunction(float x, List<float> coeffs)
        {
            return coeffs[0]* MathF.Pow(x, 4) + coeffs[1] * MathF.Pow(x, 3) + coeffs[2] * MathF.Pow(x, 2) + coeffs[3] * x + coeffs[4];
        }

        private static float FitFunction(float x, float y, List<float> coeffs)
        {
            return coeffs[0] * MathF.Pow(x, 3) + coeffs[1] * MathF.Pow(y, 3) + coeffs[2] * MathF.Pow(x, 2) * y + coeffs[3] * x * MathF.Pow(y, 2) + coeffs[4] * MathF.Pow(x, 2) + coeffs[5] * MathF.Pow(y, 2) +
                   coeffs[6] * x + coeffs[7] * y + coeffs[8] + coeffs[9] * MathF.Pow(x, 2) * MathF.Pow(y, 2) + coeffs[10] * MathF.Pow(x, 4) + coeffs[11] * MathF.Pow(y, 4);
        }

        public static (float, float) sat_h_from_p(float pressure)
        {
            List<float> a = new List<float> { -0.0000149336f, 0.0038688008f, -0.3891794483f, 23.4563918673f, 563.9888888891f };
            float h_liq = QuarticFunction(pressure, a);

            List<float> b = new List<float> { -0.0000054371f, 0.0013752914f, -0.1372686480f, 5.2360139859f, 2737.4500000007f };
            float h_gas = QuarticFunction(pressure, b);
            return (h_liq, h_gas);
        }

        public static(float, float) sat_s_from_p(float pressure)
        {
            List<float> a = new List<float> { -3.64e-8f, 0.0000093634f, -0.0009297214f, 0.0519233858f, 1.7049166667f };
            float s_liq = QuarticFunction(pressure, a);

            List<float> b = new List<float> { 3.18e-8f, -0.000008127f, 0.0007885415f, -0.0422933696f, 6.9350055556f };
            float s_gas = QuarticFunction(pressure, b);
            return (s_liq, s_gas);
        }

        public static float sat_t_from_p(float pressure)
        {
            List<float> a = new List<float> { -0.000003557f, 0.000919609f, -0.0927612277f, 5.3634364931f, 134.8337777778f };
            return QuarticFunction(pressure, a);
        }

        public static float FindQuality(float value, float value_liq, float value_gas)
        {
            return (value - value_liq) / (value_gas - value_liq);
        }

        public static float h_from_p_t(float pressure, float temperature)
        {
            List<float> LiqCoeffs = new List<float>() { -5.86000000e-06f,  2.74000000e-07f, -1.54000000e-06f, -9.25000000e-07f,  8.60853208e-04f, -3.73000000e-05f,  4.13374253e+00f,  9.67650690e-02f,  7.37596408e-01f,  5.50000000e-09f,  2.29000000e-08f,  4.82000000e-10f };
            List<float> GasCoeffs = new List<float>() {  9.62000000e-07f, -3.85814184e-04f,  1.01000000e-06f,  7.65000000e-05f, -1.32212151e-03f,  3.61359423e-03f,  2.93092405e+00f, -2.98563786e+00f,  2.28110251e+03f, -3.84000000e-08f, -1.99000000e-10f,  1.61000000e-06f };

            float sat_t = sat_t_from_p(pressure);

            if (temperature <= sat_t)   return FitFunction(temperature, pressure, LiqCoeffs);
            else                        return FitFunction(temperature, pressure, GasCoeffs);
        }

        public static float s_from_p_t(float pressure, float temperature)
        {
            List<float> LiqCoeffs = new List<float>() {  4.18000000e-08f, -1.69000000e-07f, -4.85000000e-09f,  1.87000000e-09f, -2.55000000e-05f,  1.02000000e-05f,  1.52102850e-02f, -2.58755788e-04f,  3.27046145e-03f,  1.08000000e-11f, -1.38000000e-11f,  8.94000000e-10f };
            List<float> GasCoeffs = new List<float>() {  2.92000000e-09f, -1.23000000e-05f,  1.33000000e-09f,  1.05000000e-07f, -5.82000000e-06f,  1.14493417e-03f,  6.85258265e-03f, -6.14657587e-02f,  5.99739720e+00f, -5.35000000e-11f, -5.51000000e-13f,  4.85000000e-08f };

            float sat_t = sat_t_from_p(pressure);

            if (temperature <= sat_t) return FitFunction(temperature, pressure, LiqCoeffs);
            else return FitFunction(temperature, pressure, GasCoeffs);
        }

        public static (float, float) h_from_p_s(float pressure, float entropy)
        {
            List<float> LiqCoeffs = new List<float>() { 2.82686430e+00f, 4.68000000e-05f, 6.25412936e-03f, -2.28692398e-04f, 3.34717190e+01f, -2.72505635e-03f, 2.71802853e+02f, 1.62376587e-01f, -1.12539636e-01f,  3.91000000e-05f, -4.06042675e-02f, -2.46000000e-07f };
            List<float> GasCoeffs = new List<float>() { 9.55570289e+01f,  8.71318594e-03f,  7.34276356e-01f, -4.37275447e-02f, -1.19032493e+03f, -4.32590167e-01f,  6.23904442e+03f,  2.13837619e+00f, -9.86805741e+03f, -1.13539097e-03f, -2.32938419e+00f, -3.57000000e-05f};

            var (liqSatS, gasSatS) = sat_s_from_p(pressure);
            if (entropy < liqSatS)
            {
                return (FitFunction(entropy, pressure, LiqCoeffs), 0);
            }
            else if (entropy > gasSatS)
            {
                return (FitFunction(entropy, pressure, GasCoeffs), 1);
            }
            else
            {
                float x = FindQuality(entropy, liqSatS, gasSatS);
                var (liqSatH, gasSatH) = sat_h_from_p(pressure);
                float enthalpy = x * (gasSatH - liqSatH) + liqSatH;
                return (enthalpy, x);
            }
        }

        public static (float, float) s_from_p_h(float pressure, float enthalpy)
        {
            List<float> LiqCoeffs = new List<float>() {  6.17000000e-10f, -1.69000000e-07f,  3.90000000e-12f,  3.72000000e-09f, -1.51000000e-06f,  9.34000000e-06f,  3.65988995e-03f, -5.27679053e-04f,  4.16000000e-05f, -2.27000000e-12f, -1.23000000e-13f,  8.99000000e-10f };
            List<float> GasCoeffs = new List<float>() {  2.00000000e-10f, -1.14000000e-05f, -4.96000000e-11f, -2.33000000e-08f, -1.82000000e-06f,  1.16314515e-03f,  8.12271731e-03f, -5.55182164e-02f, -5.22991193e+00f,  2.61000000e-12f, -8.52000000e-15f,  4.50000000e-08f };

            var (liqSatH, gasSatH) = sat_h_from_p(pressure);
            if (enthalpy < liqSatH)
            {
                return (FitFunction(enthalpy, pressure, LiqCoeffs), 0);
            }
            else if (enthalpy > gasSatH)
            {
                return (FitFunction(enthalpy, pressure, GasCoeffs), 1);
            }
            else
            {
                float x = FindQuality(enthalpy, liqSatH, gasSatH);
                var (liqSatS, gasSatS) = sat_s_from_p(pressure);
                float entropy = x * (gasSatS - liqSatS) + liqSatS;
                return (entropy, x);
            }
        }

        public static (float, float) t_from_p_h(float pressure, float enthalpy)
        {
            List<float> LiqCoeffs = new List<float>() {  2.17000000e-10f,  3.21000000e-08f,  1.58000000e-08f,  5.15000000e-08f, -1.11000000e-06f, -1.76000000e-05f,  2.39888047e-01f, -2.12263288e-02f, -1.36438003e-01f, -2.56000000e-11f, -6.61000000e-12f, -1.74000000e-10f };
            List<float> GasCoeffs = new List<float>() { -5.24000000e-08f,  1.36209577e-04f, -4.41000000e-08f, -1.86000000e-05f,  3.75895158e-04f,  2.67274887e-02f, -6.94975661e-01f,  1.68491418e+00f,  1.82777474e+02f,  2.07000000e-09f,  2.54000000e-12f, -5.87000000e-07f };

            var (liqSatH, gasSatH) = sat_h_from_p(pressure);
            if (enthalpy < liqSatH)
            {
                return (FitFunction(enthalpy, pressure, LiqCoeffs), 0);
            }
            else if (enthalpy > gasSatH)
            {
                return (FitFunction(enthalpy, pressure, GasCoeffs), 1);
            }
            else
            {
                float x = FindQuality(enthalpy, liqSatH, gasSatH);
                float temp = sat_t_from_p(pressure);
                return (temp, x);
            }
        }
    }
}
