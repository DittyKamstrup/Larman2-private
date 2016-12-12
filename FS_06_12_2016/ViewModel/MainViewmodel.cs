using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using FS_06_12_2016.Model;

namespace FS_06_12_2016.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        //------------------------------------------------------------------------------
        // Gør det muligt at vælge og aktivere hus fra listerne. F.eks opdatere og frameld.
        private TilmeldteHuse selectedHuse;

        public TilmeldteHuse SelectedHus
        {
            get { return selectedHuse; }
            set
            {
                selectedHuse = value;
                OnPropertyChanged(nameof(SelectedHus));
            }
        }

        //--------------------------------------------------------------------------------

        // Tæller hvor mange der deltager på den pågældende dag.
        private double ialt = 0;

        public double Ialt
        {
            get { return ialt; }
            private set
            {
                ialt = value;
                OnPropertyChanged(nameof(Ialt));
            }
        }


        public Uge NyUge { get; set; }

        public Dag UgeDag { get; set; }
        //public TilmeldteHuse hus1;
        //public Uge uge1;

        //private double samletPris;

        //public double SamletPris
        //{
        //    get { return samletPris; }
        //    set { samletPris = value; }
        //}

        private double kuvert;

        public double Kuvert
        {
            get { return kuvert; }
            set
            {
                kuvert = value;
                OnPropertyChanged(nameof(Kuvert));
            }
        }

        private double udgiftUge;

        public double UdgiftUge
        {
            get { return udgiftUge; }
            set
            {
                udgiftUge = value;
                OnPropertyChanged(nameof(UdgiftUge));
            }
        }

        private ItemsChangeObservableCollection<TilmeldteHuse> alletilmeldtehuse;

        public ItemsChangeObservableCollection<TilmeldteHuse> Alletilmeldtehuse
        {
            get { return alletilmeldtehuse; }
            set
            {
                alletilmeldtehuse = value;
                OnPropertyChanged(nameof(Alletilmeldtehuse));
            }
        }
        public Model.TilmeldteHuse NewHus { get; set; }
        #endregion

        public RelayCommand IndtastUdgiftCommand { get; set; }
        public RelayCommand OpretUgeCommand { get; set; }
        public RelayCommand FjernEtHus { get; set; }

        public RelayCommand OpretEtHus { get; set; }

        public MainViewModel()
        {
            Alletilmeldtehuse = new ItemsChangeObservableCollection<TilmeldteHuse>();
            TilmeldteHuse hus = new TilmeldteHuse();

            OpretUgeCommand = new RelayCommand(LavNyUge);
            FjernEtHus = new RelayCommand(FjernHusFraDag);
            IndtastUdgiftCommand = new RelayCommand(Beregn);
            OpretEtHus = new RelayCommand(AddNewHus);
            TilmeldteHuse hus1 = new TilmeldteHuse(18, 2, 3, 1);
            TilmeldteHuse hus2 = new TilmeldteHuse(21, 1, 1, 1);
            TilmeldteHuse hus3 = new TilmeldteHuse(19, 2, 2, 0);

            Alletilmeldtehuse.Add(hus1);
            Alletilmeldtehuse.Add(hus2);
            Alletilmeldtehuse.Add(hus3);

            //opretter to nye dag og giver dem hver sin liste
            //Dag mandag = new Dag(alletilmeldtehuse);
            //Dag tirsDag = new Dag(alletilmeldtehuse);



            List<Dag> temp_uge = new List<Dag>();

            //temp_uge.Add(mandag);
            //temp_uge.Add(tirsDag);

            //this.uge1 = new Uge(temp_uge);
            //this.SamletPris = uge1.SumKuvertUge();
            NewHus = new TilmeldteHuse();


            NyUge = new Uge();


        }

        public void AddNewHus()
        {
            //TilmeldteHuse hus = new TilmeldteHuse();
            //hus = NewHus;
            // Outcommented. No reason to create local variable when property can just be used directly.
            // just use NewHus instead of hus :)

            //kopiere et hus og lægger det ind
            TilmeldteHuse mandag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn);
            NyUge.MandagListe.Alletilmeldtehuse.Add(mandag_hus);

            TilmeldteHuse tirsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn);
            NyUge.TirsdagListe.Alletilmeldtehuse.Add(tirsdag_hus);

            TilmeldteHuse onsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn);
            NyUge.OnsdagListe.Alletilmeldtehuse.Add(onsdag_hus);

            TilmeldteHuse torsdag_hus = new TilmeldteHuse(NewHus.HusNr, NewHus.AntalVoksen, NewHus.AntalUng, NewHus.AntalBarn);
            NyUge.TorsDagListe.Alletilmeldtehuse.Add(torsdag_hus);

            this.alletilmeldtehuse.Add(NewHus);


        }

        /// <summary>
        /// 
        /// </summary>
        public void LavNyUge()
        {

            foreach (var hus in alletilmeldtehuse)
            {

                //kopiere det hus den er nået til på listen
                TilmeldteHuse mandag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn);
                NyUge.MandagListe.Alletilmeldtehuse.Add(mandag_hus);

                TilmeldteHuse tirsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn);
                NyUge.TirsdagListe.Alletilmeldtehuse.Add(tirsdag_hus);

                TilmeldteHuse onsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn);
                NyUge.OnsdagListe.Alletilmeldtehuse.Add(onsdag_hus);

                TilmeldteHuse torsdag_hus = new TilmeldteHuse(hus.HusNr, hus.AntalVoksen, hus.AntalUng, hus.AntalBarn);
                NyUge.TorsDagListe.Alletilmeldtehuse.Add(torsdag_hus);

            }

            IaltiListe();
        }
        public void IaltiListe()
        {

            Ialt = NyUge.MandagListe.SumKuvertDag();
            //Ialt = NyUge.MandagListe.Alletilmeldtehuse.Count();
        }
        //--------------------------------------
        //Fjern et hus fra listen en bestemt dag.
        public void FjernHusFraDag()
        {
            NyUge.MandagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.TirsdagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.OnsdagListe.Alletilmeldtehuse.Remove(SelectedHus);
            NyUge.TorsDagListe.Alletilmeldtehuse.Remove(SelectedHus);
        }
        //--------------------------------------

        public void GetUdgiftPrUgePrHus(TilmeldteHuse hus)
        {
            double antal = hus.AntalKuverter;
            double pris = antal * kuvert;
            hus.DagsPris = pris;

        }

        public void Beregn()
        {
            NyUge.UdgiftUge = this.udgiftUge;
            this.Kuvert = NyUge.GetKuvertPrisUgen();

            // Workaround by Martin Bagge.
            // For some reason, the OnPropertyChanged is raised too early for some of the objects
            // This means that not all objects are updated in the view.

            // Worked around this by simply pouring the entire list into a new local list
            // Then after doing operation, poured it back into the bound list. Now the view updates everything at the same time.

            var alleHuseBeregnet = Alletilmeldtehuse;
            Alletilmeldtehuse = new ItemsChangeObservableCollection<TilmeldteHuse>();

            foreach (var hus in alleHuseBeregnet)
            {
                GetUdgiftPrUgePrHus(hus);
            }
            Alletilmeldtehuse = alleHuseBeregnet;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
