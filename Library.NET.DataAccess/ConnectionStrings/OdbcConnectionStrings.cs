using System.Data.Odbc;

namespace Library.NET.DataAccess.ConnectionStrings;
public class OdbcConnectionStrings
{
    public static string ConnectionString(OdbcConnection connection)
    {
        OdbcConnectionStringBuilder connString = connection switch
        {
            OdbcConnection.KerberosSSL => new()
            {
                { "System", "MyOdbcDataSource" },
                { "Driver", "IBM i Access ODBC Driver" },
                { "TRANSLATE", 1 },
                { "SIGNON", 4 },
                { "SSL", 1 }
            },
            OdbcConnection.ADADSNSettings => new()
            {
                { "System", "MyOdbcDataSource" },
                { "Driver", "IBM i Access ODBC Driver" },
                { "SIGNON", 4 },
                { "SSL", 1 },
                { "CMT", 2 },
                { "CONNTYPE", 1 },
                { "DBQ", "CUDTAJIM,CULIBJIM,USLIBJIM" },
                { "MAXDECPREC", 31 },
                { "MAXDECSCALE", 31 },
                { "MINDIVSCALE", 0 },
                { "NAM", 0 },
                { "DFT", 5 },
                { "DSP", 1 },
                { "DEC", 0 },
                { "DECFLOATROUNDMODE", 1 },
                { "TFT", 0 },
                { "TSP", 0 },
                { "TSFT", 0 },
                { "MAPDECIMALFLOATDESCRIBE", 1 },
                { "DFTPKGLIB", "QGPL" },
                { "XDYNAMIC", 1 },
                { "PGK", "A/DEFAULT(IBM),2,0,1,0,512" },
                { "BLOCKFETCH", 1 },
                { "BLOCKSIZE", 256 },
                { "COMPRESSION", 1 },
                { "CONCURRENCY", 0 },
                { "CURSORSENSITIVITY", 0 },
                { "EXTCOLINFO", 0 },
                { "LAZYCLOSE", 0 },
                { "MAXFIELDLEN", 32 },
                { "PREFETCH", 1 },
                { "QRYSTGLMT", "*NOMAX" },
                { "QUERYOPTIMIZEGOAL", 0 },
                { "QUERYTIMEOUT", 1 },
                { "SORTTYPE", 0 },
                { "LIBVIEW", 0 },
                { "REMARKS", 0 },
                { "SEARCHPATTERN", 1 },
                { "HEXPARSEROPT", 0 },
                { "TRANSLATE", 0 },
                { "ALLOWUNSCHAR", 0 },
                { "CCSID", 0 }
            },
            _ => new()
        };

        return connString.ConnectionString;
    }
}

public enum OdbcConnection
{
    KerberosSSL,
    ADADSNSettings
}