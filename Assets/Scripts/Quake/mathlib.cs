using UnityEngine;

namespace Assets.Scripts.Quake
{

    public class vec_t
    {
        private float _value;

        public vec_t(float value)
        {
            this._value = value;
        }

        public static implicit operator float(vec_t vec)
        {
            return vec._value;
        }

        public static implicit operator vec_t(float value)
        {
            return new vec_t(value);
        }
    }

    public class vec3_t
    {
        private vec_t[] _value = new vec_t[3];

        public vec3_t(vec_t x, vec_t y, vec_t z)
        {
            _value[0] = x;
            _value[1] = y;
            _value[2] = z;
        }

        public static implicit operator vec3_t(Vector3 v)
        {
            return new vec3_t(v.x, v.y, v.z);
        }

        public vec_t this[int i]
        {
            get => _value[i];
            set => _value[i] = value;
        }
    }

    public partial class Global
    {
        public const float M_PI = (float)3.14159265358979323846;

        void AngleVectors(vec3_t angles, vec3_t forward, vec3_t right, vec3_t up)
        {
            var angle = (angles[YAW] * (M_PI * 2 / 360));
            var sy = sin(angle);
            var cy = cos(angle);
            angle = (angles[PITCH] * (M_PI * 2 / 360));
            var sp = sin(angle);
            var cp = cos(angle);
            angle = (angles[ROLL] * (M_PI * 2 / 360));
            var sr = sin(angle);
            var cr = cos(angle);

            forward[0] = cp * cy;
            forward[1] = cp * sy;
            forward[2] = -sp;
            right[0] = (-1 * sr * sp * cy + -1 * cr * -sy);
            right[1] = (-1 * sr * sp * sy + -1 * cr * cy);
            right[2] = -1 * sr * cp;
            up[0] = (cr * sp * cy + -sr * -sy);
            up[1] = (cr * sp * sy + -sr * cy);
            up[2] = cr * cp;
        }

        int VectorCompare(vec3_t v1, vec3_t v2)
        {
            int i;

            for (i = 0; i < 3; i++)
                if (v1[i] != v2[i])
                    return 0;

            return 1;
        }

        void VectorMA(vec3_t veca, float scale, vec3_t vecb, vec3_t vecc)
        {
            vecc[0] = veca[0] + scale * vecb[0];
            vecc[1] = veca[1] + scale * vecb[1];
            vecc[2] = veca[2] + scale * vecb[2];
        }

        void CrossProduct(vec3_t v1, vec3_t v2, vec3_t cross)
        {
            cross[0] = v1[1] * v2[2] - v1[2] * v2[1];
            cross[1] = v1[2] * v2[0] - v1[0] * v2[2];
            cross[2] = v1[0] * v2[1] - v1[1] * v2[0];
        }

        vec_t Length(vec3_t v)
        {
            int i;
            float length;

            length = 0;
            for (i = 0; i < 3; i++)
                length += v[i] * v[i];
            length = sqrt(length);      // FIXME

            return length;
        }

        float VectorNormalize(vec3_t v)
        {
            float length, ilength;

            length = v[0] * v[0] + v[1] * v[1] + v[2] * v[2];
            length = sqrt(length);      // FIXME

            if (length != 0)
            {
                ilength = 1 / length;
                v[0] *= ilength;
                v[1] *= ilength;
                v[2] *= ilength;
            }

            return length;
        }

        void VectorInverse(vec3_t v)
        {
            v[0] = -v[0];
            v[1] = -v[1];
            v[2] = -v[2];
        }

        void VectorScale(vec3_t _in, vec_t scale, vec3_t _out)
        {
            _out[0] = _in[0]*scale;
            _out[1] = _in[1]*scale;
            _out[2] = _in[2]*scale;
        }
    }
}