using System;

namespace Assets.Scripts.Quake
{
    public partial class Global
    {

        /// <summary>
        /// Copies the string pointed to by src, including the null character, to the buffer pointed to by dest.
        /// </summary>
        /// <param name="dest">The pointer to the destination buffer.</param>
        /// <param name="src">The pointer to the source string.</param>
        public void Q_strcpy(ref string dest, string src)
        {
            var i = 0;
            while (i < src.Length)
            {
                dest += src[i];
                i++;
            }
            dest += '\0';
        }

        void Q_strncpy(char[] dest, char[] src, int count)
        {
            int i = 0;
            while (i < count && i < src.Length && src[i] != '\0')
            {
                dest[i] = src[i];
                i++;
            }
            while (i < count)
            {
                dest[i] = '\0';
                i++;
            }
        }

        public int Q_strlen(char[] str)
        {
            int count = 0;
            while (str[count] != '\0')
            {
                count++;
            }

            return count;
        }
    }
}