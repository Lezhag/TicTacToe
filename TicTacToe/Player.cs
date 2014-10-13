//class for storing player information - name, playing token (x or o)
namespace TicTacToe
{
    public class Player
    {
        #region Properties
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int? _token;

        public int? Token
        {
            get { return _token; }
            set { _token = value; }
        } 
        #endregion

        #region Constructors
        //default ctor
        public Player()
        { }
        //custom ctor that initiates the class with the necessary info
        public Player(string n, int? t)
        {
            _name = n;
            _token = t;
        } 
        #endregion

        #region Operator overload funcs
        public static bool operator ==(Player p1, Player p2)
        {
            return ((p1._name == p2._name) && (p1._token == p2._token));
        }

        public static bool operator !=(Player p1, Player p2)
        {
            return ((p1._name != p2._name) && (p1._token != p2._token));
        } 
        #endregion
    }
}
