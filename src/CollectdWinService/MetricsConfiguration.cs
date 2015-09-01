﻿using System;
using System.Configuration;

namespace BloombergFLP.CollectdWin
{
    internal class CollectdWinConfig : ConfigurationSection
    {
        [ConfigurationProperty("GeneralSettings", IsRequired = false)]
        public GeneralSettingsConfig GeneralSettings
        {
            get { return (GeneralSettingsConfig) base["GeneralSettings"]; }
            set { base["GeneralSettings"] = value; }
        }

        [ConfigurationProperty("PluginRegistry", IsRequired = true)]
        [ConfigurationCollection(typeof (PluginCollection), AddItemName = "Plugin")]
        public PluginCollection PluginRegistry
        {
            get { return (PluginCollection) base["PluginRegistry"]; }
            set { base["PluginRegistry"] = value; }
        }

        [ConfigurationProperty("ReadStatsd", IsRequired = false)]
        public ReadStatsdConfig ReadStatsd
        {
            get { return (ReadStatsdConfig)base["ReadStatsd"]; }
            set { base["ReadStatsd"] = value; }
        }

        [ConfigurationProperty("Amqp", IsRequired = false)]
        public AmqpConfig Amqp
        {
            get { return (AmqpConfig) base["Amqp"]; }
            set { base["Amqp"] = value; }
        }

        [ConfigurationProperty("WriteHTTP", IsRequired = false)]
        public WriteHTTPConfig WriteHTTP
        {
            get { return (WriteHTTPConfig)base["WriteHTTP"]; }
            set { base["WriteHTTP"] = value; }
        }

        [ConfigurationProperty("WriteNetuitive", IsRequired = false)]
        public WriteNetuitiveConfig WriteNetuitive
        {
            get { return (WriteNetuitiveConfig)base["WriteNetuitive"]; }
            set { base["WriteNetuitive"] = value; }
        }

        [ConfigurationProperty("WriteStatsd", IsRequired = false)]
        public WriteStatsdConfig WriteStatsd
        {
            get { return (WriteStatsdConfig)base["WriteStatsd"]; }
            set { base["WriteStatsd"] = value; }
        }

        [ConfigurationProperty("WindowsEnvironmentVariables", IsRequired = false)]
        [ConfigurationCollection(typeof(WindowsEnvironmentVariableCollection), AddItemName = "EnvironmentVariable")]
        public WindowsEnvironmentVariableCollection EnvironmentVariableList
        {
            get { return (WindowsEnvironmentVariableCollection)base["WindowsEnvironmentVariables"]; }
            set { base["WindowsEnvironmentVariables"] = value; }
        }




        [ConfigurationProperty("WindowsPerformanceCounters", IsRequired = false)]
        public WindowsPerformanceCountersConfig WindowsPerformanceCounters
        {
            get { return (WindowsPerformanceCountersConfig) base["WindowsPerformanceCounters"]; }
            set { base["WindowsPerformanceCounters"] = value; }
        }

        public static CollectdWinConfig GetConfig()
        {
            return (CollectdWinConfig) ConfigurationManager.GetSection("CollectdWinConfig") ?? new CollectdWinConfig();
        }

        public sealed class AmqpConfig : ConfigurationElement
        {
            [ConfigurationProperty("Publish", IsRequired = false)]
            public PublishConfig Publish
            {
                get { return (PublishConfig) base["Publish"]; }
                set { base["Publish"] = value; }
            }

            public sealed class PublishConfig : ConfigurationElement
            {
                [ConfigurationProperty("Name", IsRequired = true)]
                public string Name
                {
                    get { return (string) base["Name"]; }
                    set { base["Name"] = value; }
                }

                [ConfigurationProperty("Host", IsRequired = false)]
                public string Host
                {
                    get { return (string) base["Host"]; }
                    set { base["Host"] = value; }
                }

                [ConfigurationProperty("Port", IsRequired = true)]
                public int Port
                {
                    get { return (int) base["Port"]; }
                    set { base["Port"] = value; }
                }

                [ConfigurationProperty("VirtualHost", IsRequired = false)]
                public string VirtualHost
                {
                    get { return (string) base["VirtualHost"]; }
                    set { base["VirtualHost"] = value; }
                }

                [ConfigurationProperty("User", IsRequired = false)]
                public string User
                {
                    get { return (string) base["User"]; }
                    set { base["User"] = value; }
                }

                [ConfigurationProperty("Password", IsRequired = false)]
                public string Password
                {
                    get { return (string) base["Password"]; }
                    set { base["Password"] = value; }
                }

                [ConfigurationProperty("Exchange", IsRequired = false)]
                public string Exchange
                {
                    get { return (string) base["Exchange"]; }
                    set { base["Exchange"] = value; }
                }

                [ConfigurationProperty("RoutingKeyPrefix", IsRequired = false)]
                public string RoutingKeyPrefix
                {
                    get { return (string) base["RoutingKeyPrefix"]; }
                    set { base["RoutingKeyPrefix"] = value; }
                }
            }
        }

        public sealed class WriteHTTPConfig : ConfigurationElement
        {
            [ConfigurationProperty("Url", IsRequired = true)]
            public String Url
            {
                get { return (string)base["Url"]; }
                set { base["Url"] = value; }
            }
        }

        public sealed class WriteStatsdConfig : ConfigurationElement
        {
            [ConfigurationProperty("Host", IsRequired = true)]
            public String Host
            {
                get { return (string)base["Host"]; }
                set { base["Host"] = value; }
            }
            [ConfigurationProperty("Port", IsRequired = true)]
            public int Port
            {
                get { return (int)base["Port"]; }
                set { base["Port"] = value; }
            }

            [ConfigurationProperty("Prefix", IsRequired = false)]
            public String Prefix
            {
                get { return (string)base["Prefix"]; }
                set { base["Prefix"] = value; }
            }        
        }

        public sealed class WriteNetuitiveConfig : ConfigurationElement
        {
            [ConfigurationProperty("Url", IsRequired = true)]
            public String Url
            {
                get { return (string)base["Url"]; }
                set { base["Url"] = value; }
            }

            [ConfigurationProperty("Location", IsRequired = false)]
            public String Location
            {
                get { return (string)base["Location"]; }
                set { base["Location"] = value; }
            }

            [ConfigurationProperty("Type", IsRequired = false)]
            public String Type
            {
                get { return (string)base["Type"]; }
                set { base["Type"] = value; }
            }
            [ConfigurationProperty("PayloadSize", IsRequired = false)]
            public int PayloadSize
            {
                get { return (int)base["PayloadSize"]; }
                set { base["PayloadSize"] = value; }
            }

        }

        public sealed class EnvironmentVariableConfig : ConfigurationElement
        {
            [ConfigurationProperty("Name", IsRequired = true)]
            public String Name
            {
                get { return (string)base["Name"]; }
                set { base["Name"] = value; }
            }

            [ConfigurationProperty("Value", IsRequired = true)]
            public String Value
            {
                get { return (string)base["Value"]; }
                set { base["Value"] = value; }
            }



            [ConfigurationProperty("Counters", IsRequired = false)]
            [ConfigurationCollection(typeof(CounterConfigCollection), AddItemName = "Counter")]
            public CounterConfigCollection Counters
            {
                get { return (CounterConfigCollection)base["Counters"]; }
                set { base["Counters"] = value; }
            }
        }

        public class WindowsEnvironmentVariableCollection : ConfigurationElementCollection
        {

            protected override ConfigurationElement CreateNewElement()
            {
                return new EnvironmentVariableConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                var envVariableConfig = (EnvironmentVariableConfig)element;
                return (envVariableConfig.Name + "_" + envVariableConfig.Value);
            }
        }

        
        public sealed class CounterConfig : ConfigurationElement
        {
            [ConfigurationProperty("Category", IsRequired = true)]
            public string Category
            {
                get { return (string) base["Category"]; }
                set { base["Category"] = value; }
            }

            [ConfigurationProperty("Name", IsRequired = true)]
            public string Name
            {
                get { return (string) base["Name"]; }
                set { base["Name"] = value; }
            }


            [ConfigurationProperty("Instance", IsRequired = false)]
            public string Instance
            {
                get { return (string) base["Instance"]; }
                set { base["Instance"] = value; }
            }

            [ConfigurationProperty("CollectdPlugin", IsRequired = true)]
            public string CollectdPlugin
            {
                get { return (string) base["CollectdPlugin"]; }
                set { base["CollectdPlugin"] = value; }
            }

            [ConfigurationProperty("CollectdPluginInstance", IsRequired = false)]
            public string CollectdPluginInstance
            {
                get { return (string) base["CollectdPluginInstance"]; }
                set { base["CollectdPluginInstance"] = value; }
            }

            [ConfigurationProperty("CollectdType", IsRequired = true)]
            public string CollectdType
            {
                get { return (string) base["CollectdType"]; }
                set { base["CollectdType"] = value; }
            }

            [ConfigurationProperty("CollectdTypeInstance", IsRequired = true)]
            public string CollectdTypeInstance
            {
                get { return (string) base["CollectdTypeInstance"]; }
                set { base["CollectdTypeInstance"] = value; }
            }

            [ConfigurationProperty("Multiplier", IsRequired = false, DefaultValue=1.0)]
            public double Multiplier
            {
                get { return (double)base["Multiplier"]; }
                set { base["Multiplier"] = value; }
            }

            [ConfigurationProperty("DecimalPlaces", IsRequired = false, DefaultValue = -1)]
            public int DecimalPlaces
            {
                get { return (int)base["DecimalPlaces"]; }
                set { base["DecimalPlaces"] = value; }
            }        
        }

        public class CounterConfigCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new CounterConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                var counterConfig = (CounterConfig) element;
                return (counterConfig.Category + "_" + counterConfig.Name + "_" + counterConfig.Instance);
            }
        }

        public sealed class GeneralSettingsConfig : ConfigurationElement
        {
            [ConfigurationProperty("Interval", IsRequired = true)]
            public int Interval
            {
                get { return (int) base["Interval"]; }
                set { base["Interval"] = value; }
            }

            [ConfigurationProperty("Timeout", IsRequired = true)]
            public int Timeout
            {
                get { return (int) base["Timeout"]; }
                set { base["Timeout"] = value; }
            }

            [ConfigurationProperty("StoreRates", IsRequired = true)]
            public bool StoreRates
            {
                get { return (bool) base["StoreRates"]; }
                set { base["StoreRates"] = value; }
            }

            [ConfigurationProperty("Hostname", IsRequired = false)]
            public string Hostname
            {
                get { return (string)base["Hostname"]; }
                set { base["Hostname"] = value; }
            }
        }

        public class PluginCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new PluginConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return (((PluginConfig) element).UniqueId);
            }
        }

        public sealed class PluginConfig : ConfigurationElement
        {
            public PluginConfig()
            {
                UniqueId = Guid.NewGuid();
            }

            internal Guid UniqueId { get; set; }

            [ConfigurationProperty("Name", IsRequired = true)]
            public string Name
            {
                get { return (string) base["Name"]; }
                set { base["Name"] = value; }
            }

            [ConfigurationProperty("Class", IsRequired = true)]
            public string Class
            {
                get { return (string) base["Class"]; }
                set { base["Class"] = value; }
            }

            [ConfigurationProperty("Enable", IsRequired = true)]
            public bool Enable
            {
                get { return (bool) base["Enable"]; }
                set { base["Enable"] = value; }
            }
        }

        public sealed class ReadStatsdConfig : ConfigurationElement
        {
            [ConfigurationProperty("Host", IsRequired = false)]
            public string Host
            {
                get { return (string) base["Host"]; }
                set { base["Host"] = value; }
            }

            [ConfigurationProperty("Port", IsRequired = true)]
            public int Port
            {
                get { return (int) base["Port"]; }
                set { base["Port"] = value; }
            }

            [ConfigurationProperty("DeleteCache", IsRequired = true)]
            public DeleteCacheConfig DeleteCache
            {
                get { return (DeleteCacheConfig) base["DeleteCache"]; }
                set { base["DeleteCache"] = value; }
            }

            [ConfigurationProperty("Timer", IsRequired = true)]
            public TimerConfig Timer
            {
                get { return (TimerConfig) base["Timer"]; }
                set { base["Timer"] = value; }
            }

            public sealed class DeleteCacheConfig : ConfigurationElement
            {
                [ConfigurationProperty("Counters", IsRequired = true)]
                public bool Counters
                {
                    get { return (bool) base["Counters"]; }
                    set { base["Counters"] = value; }
                }

                [ConfigurationProperty("Timers", IsRequired = true)]
                public bool Timers
                {
                    get { return (bool) base["Timers"]; }
                    set { base["Timers"] = value; }
                }

                [ConfigurationProperty("Gauges", IsRequired = true)]
                public bool Gauges
                {
                    get { return (bool) base["Gauges"]; }
                    set { base["Gauges"] = value; }
                }

                [ConfigurationProperty("Sets", IsRequired = true)]
                public bool Sets
                {
                    get { return (bool) base["Sets"]; }
                    set { base["Sets"] = value; }
                }
            }

            public class PercentileCollection : ConfigurationElementCollection
            {
                protected override ConfigurationElement CreateNewElement()
                {
                    return new PercentileConfig();
                }

                protected override object GetElementKey(ConfigurationElement element)
                {
                    return (((PercentileConfig) element).UniqueId);
                }
            }

            public sealed class PercentileConfig : ConfigurationElement
            {
                public PercentileConfig()
                {
                    UniqueId = Guid.NewGuid();
                }

                internal Guid UniqueId { get; set; }

                [ConfigurationProperty("Value", IsRequired = true)]
                public float Value
                {
                    get { return (float) base["Value"]; }
                    set { base["Value"] = value; }
                }
            }

            public sealed class TimerConfig : ConfigurationElement
            {
                [ConfigurationProperty("Lower", IsRequired = true)]
                public bool Lower
                {
                    get { return (bool) base["Lower"]; }
                    set { base["Lower"] = value; }
                }

                [ConfigurationProperty("Upper", IsRequired = true)]
                public bool Upper
                {
                    get { return (bool) base["Upper"]; }
                    set { base["Upper"] = value; }
                }

                [ConfigurationProperty("Sum", IsRequired = true)]
                public bool Sum
                {
                    get { return (bool) base["Sum"]; }
                    set { base["Sum"] = value; }
                }

                [ConfigurationProperty("Count", IsRequired = true)]
                public bool Count
                {
                    get { return (bool) base["Count"]; }
                    set { base["Count"] = value; }
                }

                [ConfigurationProperty("Percentiles", IsRequired = false)]
                [ConfigurationCollection(typeof (PercentileCollection), AddItemName = "Percentile")]
                public PercentileCollection Percentiles
                {
                    get { return (PercentileCollection) base["Percentiles"]; }
                    set { base["Percentiles"] = value; }
                }
            }
        }

        public sealed class WindowsPerformanceCountersConfig : ConfigurationElement
        {
            [ConfigurationProperty("Counters", IsRequired = false)]
            [ConfigurationCollection(typeof (CounterConfigCollection), AddItemName = "Counter")]
            public CounterConfigCollection Counters
            {
                get { return (CounterConfigCollection) base["Counters"]; }
                set { base["Counters"] = value; }
            }


            [ConfigurationProperty("ReloadInterval", IsRequired =false, DefaultValue = 3600)]
            public int ReloadInterval
            {
                get { return (int)base["ReloadInterval"]; }
                set { base["ReloadInterval"] = value; }
            }
        }
    }
}

// ----------------------------------------------------------------------------
// Copyright (C) 2015 Bloomberg Finance L.P.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ----------------------------- END-OF-FILE ----------------------------------