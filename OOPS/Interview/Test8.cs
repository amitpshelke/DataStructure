//Test : CDK Global
using System;

namespace OOPS.Test8
{
    public class Test8
    {
        public string CompareVersion(string ver1, string ver2)
        {
            string[] versionData1 = new string[3];
            versionData1 = ver1.Split('.');

            string[] versionData2 = new string[3];
            versionData2 = ver2.Split('.');

            int count = 0;
            foreach (string x in versionData1)
            {
                if (x == "")
                {
                    versionData1[count] = "0";
                }

                count++;
            }

            count = 0;
            foreach (string x in versionData2)
            {
                if (x == "")
                {
                    versionData1[count] = "0";
                }

                count++;
            }

            if (Convert.ToInt16(versionData1[0]) > Convert.ToInt16(versionData2[0]))
                return ver1;
            else if (Convert.ToInt16(versionData1[0]) == Convert.ToInt16(versionData2[0]))
            {
                if (Convert.ToInt16(versionData1[1]) > Convert.ToInt16(versionData2[1]))
                    return ver1;
                else if (Convert.ToInt16(versionData1[1]) == Convert.ToInt16(versionData2[1]))
                {
                    if (Convert.ToInt16(versionData1[2]) > Convert.ToInt16(versionData2[2]))
                        return ver1;
                    else if (Convert.ToInt16(versionData1[2]) == Convert.ToInt16(versionData2[2]))
                        return ver1;
                    else
                        return ver2;
                }
            }
            else
                return ver2;

            return "";

        }
    }
}
