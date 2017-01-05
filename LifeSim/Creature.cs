using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSim
{
    class Creature
    {
        Random rand = new Random();
        Boolean good;
        Boolean empty = false;
        Boolean baby = false;
        public int age;
        Boolean dead;
        int health = 3;
        const int LOWERLIMIT = 2;
        const int UPPERLIMIT = 5;
        public int ageLimit;
        

        public Creature()
        {
            good = true;
            age = 0;
            dead = false;
            ageLimit = rand.Next(LOWERLIMIT, UPPERLIMIT);
        }

        public Creature(Boolean isGood)
        {
            good = isGood;
            age = 0;
            dead = false;
            ageLimit = rand.Next(LOWERLIMIT, UPPERLIMIT);
        }

        public Creature(int stub)
        {
            empty = true;
            baby = false;
        }

        public void Revive()
        {
            good = true;
            age = 0;
            dead = false;
            empty = false;
            ageLimit = rand.Next(LOWERLIMIT, UPPERLIMIT);
        }

        public void incAge()
        {
            age++;
        }

        public void kill()
        {
            empty = true;
        }

        public Boolean isDead()
        {
            return dead;
        }

        public void setEmpty(Boolean isEmpty)
        {
            empty = isEmpty;
        }

        public void hurtHealth()
        {
            if (health != 0)
                health--;
            else
                this.kill();
        }

        public Boolean isEmpty()
        {
            return empty;
        }

        public Boolean isGood()
        {
            return good;
        }

        public Boolean isBaby()
        {
            return baby;
        }

        public void setBaby(Boolean babeh)
        {
            baby = babeh;
        }

        public void setAge(int newAge)
        {
            age = newAge;
        }

        public Char toChar()
        {
            if (empty)
                return '.';
            else if (good)
                return '@';
            else
                return 'X';

        }
    }
}
