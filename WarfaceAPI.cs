using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace noname //Поставьте пространство имен который используете вы! | Put the namespace that you use!
{
    class WarfaceAPI
    {
        public static void CheckStats(string nickname, int server) //RU Server = 0, EU Server = 1.
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)WebRequest.Create($"http://api.warface.ru/user/stat/?name={nickname}&server={server}").GetResponse();
                JSON playerinfo = JsonConvert.DeserializeObject<JSON>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                response.Close();

            string result = @$" 
            Ник: {playerinfo.nickname},
            ID: {playerinfo.user_id},
            Клан: {playerinfo.clan_name},
            ID клана: {playerinfo.clan_id},
            Ранг:  {playerinfo.rank_id},
            Опыт: {playerinfo.experience},
            Времени в игре: {playerinfo.playtime_h} часов, {playerinfo.playtime_m} минут,

            PVP:
            У/С: {playerinfo.pvp},
            Убийств в общем: {playerinfo.kill},
            Убийств врагов: {playerinfo.kills},
            Убийств тиммейтов: {playerinfo.friendly_kills},
            Смертей: {playerinfo.death},
            Общее количество ссыграных игр: {playerinfo.pvp_all},
            Выйграно игр: {playerinfo.pvp_wins},
            Проиграно игр: {playerinfo.pvp_lost},
            Любимый класс: {playerinfo.favoritPVP},

            PVE:
            У/С: {playerinfo.pve},
            Убийств в общем: {playerinfo.pve_kill},
            Убийств врагов: {playerinfo.pve_kills},
            Убийств тиммейтов: {playerinfo.pve_friendly_kills},
            Смертей: {playerinfo.pve_death},
            Общее количество ссыграных игр: {playerinfo.pve_all},
            Выйграно игр: {playerinfo.pve_wins},
            Проиграно игр: {playerinfo.pve_lost},
            Любимый класс: {playerinfo.favoritPVE},";
            }
            catch (Exception e)
            {
                
            }
        }
        class JSON
        {
        public string user_id { get; set; }
        public string nickname { get; set; }
        public int experience { get; set; }
        public int rank_id { get; set; }
        public bool is_transparent { get; set; }
        public int clan_id { get; set; }
        public string clan_name { get; set; }
        public int kill { get; set; }
        public int friendly_kills { get; set; }
        public int kills { get; set; }
        public int death { get; set; }
        public double pvp { get; set; }
        public int pve_kill { get; set; }
        public int pve_friendly_kills { get; set; }
        public int pve_kills { get; set; }
        public int pve_death { get; set; }
        public double pve { get; set; }
        public int playtime { get; set; }
        public int playtime_h { get; set; }
        public int playtime_m { get; set; }
        public string favoritPVP { get; set; }
        public string favoritPVE { get; set; }
        public int pve_wins { get; set; }
        public int pvp_wins { get; set; }
        public int pvp_lost { get; set; }
        public int pve_lost { get; set; }
        public int pve_all { get; set; }
        public int pvp_all { get; set; }
        public float pvpwl { get; set; }
        public string full_response { get; set; }
       }
    }
}

