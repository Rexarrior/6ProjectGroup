using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneNumberRecord : RecordType
    {


        public PhoneNumberRecord():
            base("Phone number", @"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$")
        {

        }
    }



    class  EmailRecord: RecordType
    {
        public EmailRecord() :
            base("Email", "^.+@.+$")
        {

        }

    }

    class DiscordTagRecord : RecordType
    {
        public DiscordTagRecord() :
        base("Discord tag", @"^.+#\d+$")
        {

        }
    }



    public class NoTypeRecord : RecordType
    {
        public  NoTypeRecord():
            base("Without type",".*" )
        {}

    }


    

}
