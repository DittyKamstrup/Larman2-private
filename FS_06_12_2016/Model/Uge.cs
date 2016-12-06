﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Uge : INotifyPropertyChanged
    {
        public List<Dag> ugedage = new List<Dag>();
        
        public double UdgiftUge = 1800;
        public double result;
        public Dag dag;
        public Uge()
        {
            Dag mandag = new Dag();
            Dag tirsdag = new Dag();

            ugedage.Add(mandag);
            ugedage.Add(tirsdag);



        }

        /// <summary>
        /// Giver antallet af kuverter pr uge (18)
        /// </summary>
        /// <returns></returns>
        public double SumKuvertUge()
        {
            double sum = 0;

            foreach (var h in ugedage)
            {
                sum += h.SumKuvertDag();
            }
            return sum;
        }
        /// <summary>
        /// Giver den gennemsnitlige kuvertpris per uge (100 kr)
        /// </summary>
        /// <returns></returns>
        public double GetKuvertPrisUgen()
        {

            double result = 0;
            result = UdgiftUge / SumKuvertUge();

            return result;
        }

        //public double GetUdgiftPrUgePrHus()
        //{

            //for hver dag
            //foreach (var dag in ugedage)
            //{
            //    //skal lave en beregning på HVERT HUS.
            //    foreach (var hus in )
            //    {
            //        result = item.SumKuvertDag() * GetKuvertPrisUgen();
            //        return result;
            //    }

            //}
        //    return result;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}