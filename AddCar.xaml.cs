using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.ConstrainedExecution;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Autocare_WPF.domain.cars;
using Autocare_WPF.data_access;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Autocare_WPF
{
    public partial class AddCar : Window
    {
        private string _currentUsername;
        private int currentUserID;
        private Dictionary<string, List<string>> carModels = new Dictionary<string, List<string>>();

        public AddCar(string currentUsername)
        {
            InitializeComponent();
            _currentUsername =DataAccess.Instance.CurrentUsername;
            currentUserID= DataAccess.Instance.CurrentUserID;
            
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {

            string csvPath = @"D:\limbaje (c#)\Autocare WPF\2024.csv"; 
            LoadCarDataFromCSV(csvPath);

            // Load Brands dynamically from CSV
            BrandComboBox.ItemsSource = carModels.Keys.ToList();
            BrandComboBox.SelectedIndex = -1;

            // Subscribe to SelectionChanged event
            BrandComboBox.SelectionChanged += BrandComboBox_SelectionChanged;


            //// Load Brands
            //BrandComboBox.ItemsSource = new List<string> { "Abarth","Aixam","Alfa Romeo","Aston Martin","Audi","Bentley", "BMW","Bugatti","Cadillac","Chevrolet","Chrysler","Citroen","Cupra","Dacia","Daewoo","Dodge","DS Automobiles","Ferrari","Fiat","Ford","GMC","Honda","Hummer","Hyundai","Infiniti","Isuzu","Iveco","Jaguar","Jeep","Kia","Koenigsegg","Lada","Lamborghini","Lancia","Land Rover","Lexus","Lotus","Maserati","Maybach","Mazda","McLaren","Mercedes-Benz","Mini","Mitsubishi","Nissan","Opel","Peugeot","Porsche","Renault","Rolls Royce","Rover","Saab","Seat","Skoda","Smart","SsangYong","Subaru","Suzuki","Tesla","Toyota","Vauxhall","Volkswagen","Volvo" };
            //BrandComboBox.SelectedIndex = -1;

            //// Load Models for each Brand
            //carModels["Abarth"] = new List<string> { "124", "500", "595", "695", "Grande Punto","Inny" };
            //carModels["Aixam"] = new List<string> { "City", "Coupe", "Crossline", "Crossover", "D-Truck","e-Truck","Miniauto","Roadline","Scouty R" };
            //carModels["Alfa Romeo"] = new List<string> { "145", "146", "147", "155", "156","159","164","166","33","4C","Alfasud","Alfetta","Brera","Crosswagon","Giulia","Giulietta","GT","GTV","Mito","Spider","Sprint","Stelvio","Tonale" };
            //carModels["Aston Martin"] = new List<string> { "AMV8", "Bulldog", "Cygnet","DB4","DB5","DB6","DB7", "DB9", "DB11","DBS","DBX","Lagonda","One-77","Rapide","V12 Vantage","V8 Vantage","Vanquish","Virage","Volante","Zagato" };
            //carModels["Audi"] = new List<string> { "100", "200", "80", "90", "A1","A2","A3","A4","A4 Allroad","A5","A6","A6 Allroad","A7","A8","Coupe","e-tron","e-tron GT","Q2","Q3","Q4","Q5","Q6","Q7","Q8","R8","RS Q3","RS Q8","RS2","RS3","RS4","RS5","RS6","RS7","S1","S2","S3","S4","S5","S6","S7","S8","SQ2","SQ3","SQ5","SQ7","SQ8","TT","TT S","TT RS"};
            //carModels["Bentley"] = new List<string> { "Arnage", "Azure", "Bentayga", "Brooklands", "Continental","Eight","Flying Spur","Mulliner","Mulsanne","Turbo" };
            //carModels["BMW"] = new List<string> { "Alpina", "i3", "i4", "i5", "i7","i8","iX","iX1","iX2","iX3","M1","M2","M3","M4","M5","M6","M7","M8","Seria 1","Seria 2","Seria 3","Seria 4","Seria 5","Seria 6","Seria 7","Seria 8","X1","X2","X3","X3M","X4","X4M","X5","X5M","X6","X6M","X7","XM","Z1","Z3","Z3M","Z4","Z4M" };
            //carModels["Bugatti"] = new List<string> { "Chiron", "EB 110", "Tourbillon", "Veyron" };
            //carModels["Cadillac"] = new List<string> { "ATS", "BLS", "Brougham", "Cimarron", "CT5","CT6","CTS","Deville","DTS","Eldorado","Escalade","Fleetwood","Seville","SRX","STS","XLR","XT4","XT5","XT6","XTS" };
            //carModels["Chevrolet"] = new List<string> { "Avalanche", "Aveo", "Beretta", "Blazer", "Camaro" ,"Caprice","Captiva","Cavalier","Chevelle","Chevy Van","Colorado","Corsica","Corvette","Cruze","El Camino","Epica","Equinox","Evanda","Express","G","HHR","Impala","Kalos","Lacetti","Lumina","Malibu","Matiz","Nubira","Orlando","Rezzo","S-10","Silverado","Spark","Spectrum","SSR","Suburban","Tacuma","Tahoe","Trailblazer","Trans Sport","Traverse","Trax","Venture","Volt"};
            //carModels["Chrysler"] = new List<string> { "300C", "300M", "Aspen", "Caravan", "Concorde","Crossfire","Daytona","ES","Grand Voyager","GS","GTS","Le Baron","LHS","Neon","New Yorker","Pacifica","Prowler","PT Cruiser","Saratoga","Sebring","Stratus","Town & Country","Valiant","Viper","Vision","Voyager" };
            //carModels["Citroen"] = new List<string> { "AX", "Axel", "Berlingo", "BX", "C-Crosser","C-Elysee","C-ZERO","C1","C2","C3","C3 AIRCROSS","C3 Picasso","C3 Pluriel","C4","C4 Aircross","C4 Cactus","C4 Grand Picasso","C4 Grand Space Tourer","C4 Picasso","C4 Space Tourer","C4X","C5","C5 Aircross","C6","C8","Cactus","CX","DS","DS3","DS4","DS5","DS7","Evasion","GSA","Jumper","Jumpy","Nemo","Saxo","SM","SpaceTourer","Xantia" };
            //carModels["Cupra"] = new List<string> { "Ateca", "Born", "Formentor", "Leon", "Tavascan","Terramar" };
            //carModels["Dacia"] = new List<string> { "1100", "1300", "1310", "1400", "1410","Dokker","Duster","Jogger","Lodgy","Logan","Logan Stepway","Logan Van","Nova","Pick Up","Sandero","Sandero Stepway","Solenza","Spring","Super Nova" };
            //carModels["Daewoo"] = new List<string> { "Chairman", "Cielo", "Espero", "Evanda", "Kalos","Korando","Lacetti","Lanos","Leganza","Matiz","Musso","Nexia" ,"Nubira","Racer","Rezzo","Tacuma","Tico"};
            //carModels["Dodge"] = new List<string> { "Avenger", "Caliber", "Caravan", "Caravan", "Challenger","Charger","Dakota","Dart","Daytona","Diplomat","Durango","Dynasty","Grand Caravan","Hornet","Intrepid","Journey","Magnum","Monaco","Neon","Nitro","Omni","RAM","Spirit","Stealth","Stratus","Viper" };
            //carModels["DS Automobiles"] = new List<string> { "DS3", "DS3 Crossback", "DS4", "DS4", "DS4 Crossback","DS5","DS7 Crossback","DS9" };
            //carModels["Ferrari"] = new List<string> { "208", "296 GTB", "296 GTS", "328", "348","360","400","412","456","458","488 GTB","488 Spyder","512","550","575","599","612","812","California","Dino","Enzo","F12","F355","F40","F430","F50","F8","FF","FXX","GTC4Lusso","LaFerrari","Mondial","Portofino","Purosangue","Roma","SF90 Stradale","Testarosa" };
            //carModels["Fiat"] = new List<string> { "124", "125p", "126", "127", "128","130","131","132","500","500L","500X","600","850" ,"Albea","Barchetta","Brava","Bravo","Cinquecento","Coupe","Croma","Dino","Doblo","Ducato","Fiorino","Freemont","Fullback","Grande Punto","Idea","Linea","Marea","Multipla","Palio","Panda","Punto","Qubo","Regata","Ritmo","Scudo","Sedici","Seicento","Siena","Spider Europa","Stilo","Strada","Talento","Tempra","Tipo","Ulysse",""};
            //carModels["Ford"] = new List<string> { "Aspire", "B-Max", "Bronco", "Bronco Sport", "C-Max","Capri","Contour","Cougar","Courier","Crown","Econoline","Econovan","EcoSport","Edge","Escape","Escort","Excursion","Expedition","Explorer","F150","F250","F350","Fairlane","Falcon","Festiva","Fiesta","Focus","Freestar","Freestyle","Fusion","Galaxy","Granada","Grand C-Max","GT","Ka","Ka+","Kuga","Maverick","Mercury","Mondeo","Mustang","Mustang Mach-E","Orion","Probe","Puma","Ranger","Raptor","S-Max","Scorpio","Sierra","Streetka","Tourneo","Tourneo Connect","Tourneo Courier","Tourneo Custom","Transit","Transit Connect","Transit Custom" };
            //carModels["GMC"] = new List<string> { "Acadia", "Altul", "Canyon", "Envoy", "Jimmy","Safari","Savana","Sierra","Sonoma","Suburban","Syclone","Terrain","Vandura","Yukon" };
            //carModels["Honda"] = new List<string> { "Accord", "Aerodeck", "City", "Civic", "Concerto","CR-V","CR-Z","CRX","eNS1","eNY1","FR-V","Honda-e","HR-V","Insight","Integra","Jazz","Legend","Logo","NSX","Odyssey","Pilot","Prelude","Ridgeline","S 2000","Shuttle","Stream","ZR-V" };
            //carModels["Hummer"] = new List<string> { "H1", "H2", "H3" };
            //carModels["Hyundai"] = new List<string> { "Accent", "Atos", "Avante", "Azera", "Bayon","Coupe","Elantra","Excel","Galloper","Genesis","Getz","Grand Santa Fe","Grandeur","H-1","H-1 Starex","H200","H350","i10","i20","i30","i40","IONIQ","ix20","ix35","ix55","KONA","Lantra","Lavita","Matrix","Palisade","Pony","S-Coupe","Santa Fe","Santamo","Sonata","Staria","Terracan","Trajet","Tucson","Veloster","XG" };
            //carModels["Infiniti"] = new List<string> { "EX 30", "EX 35", "EX 37","FX 30","FX 35","FX 37","FX 45","FX 50","G20","G35","G37","I30","I35","J30","M30","M35","M37","Q30","Q45","Q50","Q60","Q70","QX30","QX50","QX56","QX70","QX80" };
            //carModels["Isuzu"] = new List<string> { "Campo", "D-Max", "G mini","Midi","Pickup","Trooper" };
            //carModels["Iveco"] = new List<string> { "Massif" };
            //carModels["Jaguar"] = new List<string> { "Daimler", "E-Pace", "E-Type","F-Pace","F-Type","I-Pace","MK II","S-Type","X-Type","XE","XF","XJ","XJS","XK","XK8","XKR" };
            //carModels["Jeep"] = new List<string> { "Avenger", "Cherokee", "CJ","Comanche","Commander","Compass","Gladiator","Grand Cherokee","Liberty","Patriot","Renegade","Wagoneer","Willys","Wrangler" };
            //carModels["Kia"] = new List<string> { "Asia Rocksta", "Besta", "Carens","Carnival","Cee'd","Cerato","Clarus","Elan","EV-6","EV-6 GT","EV-9","Joice","K5","Leo","Magentis","Mentor","Niro","Opirus","Optima","Picanto","Pregio","Pride","Pro Cee'd","Retona","Rio","Roadster","Rocksta","Sedona","Sephia","Shuma","Sorento","Soul","Spectra","Sportage","Stinger","Stonic","Venga","X Cee'd" };
            //carModels["Koenigsegg"] = new List<string> { "Agera", "Gemera", "Jesko","One:1","Regera" };
            //carModels["Lada"] = new List<string> { "Aleko", "Forma", "Granta","Kalina","Largus","Niva","Nova","Priora","Samara","Vesta","XRAY" };
            //carModels["Lamborghini"] = new List<string> { "Aventador", "Countach", "Diablo","Espada","Gallardo","Huracan","Jalpa","LM","Miura","Murcielago","Reventon","Revuelto","Uraco","Urus" };
            //carModels["Lancia"] = new List<string> { "Beta", "Dedra", "Delta","Flamina","Flavia","Fulvia","Gamma","Kappa","Lybra","Musa","Phedra","Prisma","Stratos","Thema","Thesis","Voyager","Ypsilon","Zeta" };
            //carModels["Land Rover"] = new List<string> { "Defender", "Discovery", "Discovery Sport","Freelander","Range Rover","Range Rover Evoque","Range Rover Sport","Range Rover Velar","Range Rover Vogue" };
            //carModels["Lexus"] = new List<string> { "CT", "LBX", "LC500","LC500h","LFA","LM","RZ","Seria ES","Seria GS","Seria GX","Seria IS","Seria LS","Seria LX","Seria NX","Seria RC","Seria RX","Seria SC","TX500H","UX" };
            //carModels["Lotus"] = new List<string> { "340R", "Cortina", "Eclat","Elan","Eletre","Elise","Elite","Emira","Espirit","Europa","Evija","Evora","Excel","Exige","V8" };
            //carModels["Maserati"] = new List<string> { "222", "224", "228","3200","418","420","4200", "422","424","430","Biturbo","Coupe","Ghibli","GranCabrio","GranSport","Grecale","Indy","Karif","Levante","MC12","MC20","Merak","Quattroporte","Shamal","Spyder" };
            //carModels["Maybach"] = new List<string> { "57", "62", "S 500","S 560 4Matic","S 560","S 580","S 680 4Matic" };
            //carModels["Mazda"] = new List<string> { "121", "2", "3","323","5","6","626","929","Bongo","BT-50","CX-3","CX-30","CX-5","CX-60","CX-7","CX-80","CX-9","Demio","Millenia","MPV","MX-3","MX-30","MX-5","MX-6","Premacy","Protege","RX-6","RX-7","RX-8","Seria B","Seria E","Tribute","Xedos" };
            //carModels["McLaren"] = new List<string> { "540C", "570GT", "570S", "600LT", "620R", "625C", "675LT", "720S", "740S Spider", "765LT", "Elva", "F1", "GT", "MP4-12C", "P1" };
            //carModels["Mercedes-Benz"] = new List<string> { "A-Class", "AMG", "AMG GT", "AMG GT-S", "B-Class","C-Class","CE","Citan","CL","CLA","CLC","CLE","CLK","CLS","E-Class","EQA","EQB","EQC","EQE","EQG","EQS","EQT","EQV","G-Class","GL","GLA","GLB","GLC","GLC Coupe","GLE","GLE Coupe","GLK","GLS","GLS Maybach","MB 100","ML","R-Class","S-Class","S Maybach","SL","SLC","SLK","SLR","SLS","Sprinter","T","V-Class","Vaneo","Vario","Viano","Vito","W108","W111","W113","W114","W115","W116","W123","W124","W126","W201","X-Class" };
            //carModels["Mini"] = new List<string> { "Clubman", "Cooper", "Cooper S","Cooper SE","Countryman","ONE","Paceman","Roadster" };
            //carModels["Mitsubishi"] = new List<string> { "3000 GT", "ASX", "Canter","Carisma","Colt","Cordia","Cosmos","Diamante","Eclipse","Eclipse-Cross","Endeavor","FTO","Galant","Galloper","Grandis","i-MiEV","L200","L300","L400","Lancer","Lancer Evolution","Mirage","Montero","Outlander","Pajero","Pajero Pinin","Santamo","Sapporo","Sigma","Space Gear","Space Runner","Space Star","Space Wagon","Starion","Tredia" };
            //carModels["Nissan"] = new List<string> { "100NX", "200SX", "240SX","280SX","300ZX","350Z","370Z","Almera","Almera Tino","Altima","Ariya","Armada","Bluebird","Ceri","Qube","Evalia","Frontier","GT-R","Interstar","Juke","Kingcab","Cubistar","Laurel","Leaf","Maxima","Micra","Murano","Navara","Note","NP-300 Pickup","NV-200","NV-300","NV-400","Pathfinder","Patrol","Pick-Up","Pixo","Prairie","Prima Star","Primera","Pulsar","Qashqai","Quest","Rogue","Sentra","Serena","Silvia","Skyline","Stanza","Sunny","Terrano","Tiida","Titan","Trade","Urvan","Vanette","X-Trail","X-Terra" };
            //carModels["Opel"] = new List<string> { "Adam", "Agila", "Ampera","Ampera-E","Antara","Arena","Ascona","Astra","Calibra","Campo","Cascada","Combo","Commodore","Corsa","Crossland","Diplomat","Frontera","GrandLand","GrandLand-X","GT","Insignia","Kadett","Karl","Manta","Meriva","Mokka","Monterei","Monza","Movano","Nova","Omega","Pickup SportCap","Rekord","Senator","Signum","Sintra","Speedster","Tigra","Vectra","Vivaro","Zafira" };
            //carModels["Peugeot"] = new List<string> { "1007", "104", "106","107","108","2008","204","205","206","207","208","3008","301","304","305","306","307","308","309","4007","4008","404","405","406","407","408","5008","504","505","508","604","605","607","806","807","Bipper","Boxer","Expert","i-ON","Partner","RCZ","Rifter","Traveler" };
            //carModels["Porsche"] = new List<string> { "356", "911", "911 TurboS","912","914","924","928","944","959","962","968","992","992 TurboS","Boxster","Carrera GT","Cayenne","Cayenne Coupe","Cayman","Macan","Panamera","Taycan" };
            //carModels["Renault"] = new List<string> { "10", "11", "12","14","16","18","19","20","21","25","30","4","5","8","9","Alaskan","Arkana","Austral","Avantime","Captur","Clio","Espace","Express","Fluence","Fuego","Grand Espace","Grand Scenic","Kadjar","Kangoo","Koleos","Laguna","Latitude","Master","Megane","Modus","Rafale","Safrane","Scenic","Scenic RX4","Symbioz","Symbol","Talisman","Traffic","Twingo","Twizy","Vel Satis","Wind","Zoe" };
            //carModels["Rolls Royce"] = new List<string> { "Corniche", "Cullinan", "Dawn","Flying Spur","Ghost","ParkWard","Phantom","SilverCloud","SilverDawn","SilverSeraph","SilverShadow","SilverSpirit","SilverSpur","Spectre","TouringLimousine","Wraith" };
            //carModels["Rover"] = new List<string> { "100", "200", "25","400","45","600","75","800","825","CityRover","Metro","Montego","SD","StreetWise"};
            //carModels["Saab"] = new List<string> { "9-2X", "9-3", "9-3X","9-4X","9-5","9-7X","90","900","9000","96","99" };
            //carModels["Seat"] = new List<string> { "Alhambra", "Altea", "Altea XL","Arona","Arosa","Ateca","Cordoba","Exeo","Ibiza","Leon","Malaga","Marbella","Mii","Ronda","Tarraco","Terra","Toledo" };
            //carModels["Skoda"] = new List<string> { "100", "105", "120","130","135","Citigo","Enyaq","Fabia","Favorit","Felicia","Forman","Kamiq","Karoq","Kodiaq","Octavia","Praktik","Rapid","Roomster","Scala","Superb","Yeti" };
            //carModels["Smart"] = new List<string> { "Crossblade", "Forfour", "Fortwo","Roadster" };
            //carModels["SsangYong"] = new List<string> { "Actyon", "Family", "Korando","Kyron","MUSSO","Rexton","Rodius","Tivoli","Tivoli Grand","Torres","XLV" };
            //carModels["Subaru"] = new List<string> { "Ascent", "B9 Tribeca", "Baja","BRZ","Crosstrek","G3X Justy","Impreza","Justy","Legacy","Leone","Levorg","Libero","Outback","Solterra","SVX","Trezia","Tribeca","Vivio","WRX STI","XT","XV" };
            //carModels["Suzuki"] = new List<string> { "Across", "Alto", "Baleno","Cappucino","Carry","Celerio","Grand Vitara","Ignis","Jimny","Kizashi","Liana","LJ","Reno","Samurai","Splash","Super-Carry","Swace","Swift","SX4","SX4 S-Cross","Vitara","Wagon R+","X-90","XL7" };
            //carModels["Tesla"] = new List<string> { "Model 3", "Model S", "Model X","Model Y","Roadster" };
            //carModels["Toyota"] = new List<string> { "4Runner", "Alphard", "Auris","Avalon","Avensis","Aygo","Aygo X","BZ4X","C-HR","Camry","Carina","Celica","Corolla","Corolla Cross","Corolla Verso","Cressida","Crown","FJ","Fortuner","GT86","Harrier","Hiace","Highlander","Hilux","iQ","Land Cruiser","Land Cruiser 250","Land Cruiser 300","Lite-Ace","Matrix","MR2","Paseo","Picnic","Previa","Prius","Prius+","Proace","RAV4","Sequoia","Sienna","Starlet","Supra","Tacoma","Tercel","Tundra","Urban Cruiser","Venza","Verso","Yaris","Yaris Cross" };
            //carModels["Vauxhall"] = new List<string> { "Astra", "Frontera", "Omega","Vectra" };
            //carModels["Volkswagen"] = new List<string> { "Amarok", "Arteon", "Atlas","Beetle","Bora","Buggy","Caddy","California","Caravelle","Corrado","Crafter","e-Golf","e-Up","Eos","Fox","Garbus","Golf","Golf Plus","Golf Sportsvan","ID.Buzz","ID.3","ID.4","ID.5","ID.6","ID.7","Iltis","Jetta","Kafer","Karmann Ghia","Lupo","Multivan","New Beetle","Passat","Passat Alltrack","Passat CC","Phaeton","Polo","Santana","Scirocco","Sharan","T-Cross","T-Roc","Taigo","Tiguan","Touareg","Touran","Transporter","up!","Vento" };
            //carModels["Volvo"] = new List<string> { "240", "340", "360","440","460","480","740","760","850","940","960","Amazon","C30","C40","C70","EX30","EX90","Polar","S40","S60","S70","S80","S90","V40","V50","V60","V70","V90","XC 40","XC 60","XC70","XC 90" };


            BrandComboBox.SelectionChanged += BrandComboBox_SelectionChanged;
            BrandComboBox_SelectionChanged(null, null); 


            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= 1980; year--)
            {
                YearComboBox.Items.Add(year);
            }
            YearComboBox.SelectedIndex = -1;

            ColorComboBox.ItemsSource = new List<string> { "Black", "White", "Gray", "Blue", "Red", "Green", "Silver", "Yellow", "Brown", "Orange" };
            ColorComboBox.SelectedIndex = -1;
        
            FuelTypeComboBox.ItemsSource = new List<string> { "Petrol", "Diesel", "Electric", "Hybrid", "LPG", "CNG" };
            FuelTypeComboBox.SelectedIndex = -1;
   
            TransmissionComboBox.ItemsSource = new List<string> { "Manual", "Automatic", "Semi-Automatic" };
            TransmissionComboBox.SelectedIndex = -1;

            PowerComboBox.ItemsSource = new List<string> { "75", "80", "100", "120", "150","170","190","200","250","300","350","400","450","500","600","700" };
            PowerComboBox.SelectedIndex = -1;

            EngineCapacityComboBox.ItemsSource = new List<string> { "900", "1000", "1200", "1400", "1500","1600","1700","1800","1900","2000","2200","2500","2800","3000","3500","4000","4200","4400","5000","5700","6000","6200" };
            EngineCapacityComboBox.SelectedIndex = -1;

            MileageComboBox.ItemsSource = new List<string> {"1000","5000", "10000","15000", "30000", "50000", "75000", "100000","125000","150000","175000","200000","250000","300000" };
            MileageComboBox.SelectedIndex = -1;

        }
        private void ComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numeric input
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$");
        }
        private void LoadCarDataFromCSV(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string headerLine = reader.ReadLine(); // Skip header line

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        if (values.Length >= 3)
                        {
                            string brand = values[1].Trim(); // Make
                            string model = values[2].Trim(); // Model

                            if (!carModels.ContainsKey(brand))
                            {
                                carModels[brand] = new List<string>();
                            }

                            if (!carModels[brand].Contains(model))
                            {
                                carModels[brand].Add(model);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading CSV: " + ex.Message);
            }
        }

        private void BrandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandComboBox.SelectedItem != null)
            {
                string selectedBrand = BrandComboBox.SelectedItem.ToString();
                if (carModels.ContainsKey(selectedBrand))
                {
                    ModelComboBox.ItemsSource = carModels[selectedBrand];
                    ModelComboBox.SelectedIndex = -1;
                }
            }
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess carDataAccess = new DataAccess();
           
            AddCarClass car = new AddCarClass
            {
                UserID = currentUserID,
                Brand = BrandComboBox.SelectedItem?.ToString() ?? "",
                Model = ModelComboBox.SelectedItem?.ToString() ?? "",
                Year = YearComboBox.SelectedItem?.ToString() ?? "",
                LicensePlate = LicensePlateTextBox.Text.Trim(),
                VIN = VINTextBox.Text.Trim(),
                Color = ColorComboBox.SelectedItem?.ToString() ?? "",
                EngineCapacity = int.TryParse(EngineCapacityComboBox.SelectedItem?.ToString(), out int engineCapacity) ? engineCapacity : 0,
                FuelType = FuelTypeComboBox.SelectedItem?.ToString() ?? "",
                HorsePower = PowerComboBox.SelectedItem?.ToString() ?? "",
                Mileage = int.TryParse(MileageComboBox.SelectedItem?.ToString(), out int mileage) ? mileage : 0,
                Transmision = TransmissionComboBox.SelectedItem?.ToString() ?? ""
               
                
            };
            // Validate required fields
            if (string.IsNullOrEmpty(car.VIN) || string.IsNullOrEmpty(car.LicensePlate) ||
                string.IsNullOrEmpty(car.Brand) || string.IsNullOrEmpty(car.Model) || string.IsNullOrEmpty(car.Year))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add the car
            bool success = carDataAccess.AddCar(car);
            if (success)
            {
                MessageBox.Show("Car added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }


    }
}