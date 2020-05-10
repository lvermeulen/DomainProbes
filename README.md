![Icon](https://i.imgur.com/rPIJswn.png?1) 
# DomainProbes
[![Build status](https://ci.appveyor.com/api/projects/status/7mo30k4xw2e3c00g?svg=true)](https://ci.appveyor.com/project/lvermeulen/domainprobes) [![license](https://img.shields.io/github/license/lvermeulen/DomainProbes.svg?maxAge=2592000)](https://github.com/lvermeulen/DomainProbes/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/vpre/DomainProbes.svg?maxAge=86400)](https://www.nuget.org/packages/DomainProbes/) ![](https://img.shields.io/badge/.net-4.5-yellowgreen.svg) ![](https://img.shields.io/badge/netstandard-1.1-yellowgreen.svg)

C# implementation of [Domain Oriented Observability](https://martinfowler.com/articles/domain-oriented-observability.html) by [Pete Hodgson](https://blog.thepete.net/about/).

## Features:
* Domain probes
* Domain contexts
* Domain announcers
* Domain monitors

## Usage:

* Domain probes:
~~~~
    public class PriceDiscountDomainProbe : IDomainProbe
    {
        private readonly IDomainAnnouncer _announcer;

        public PriceDiscountDomainProbe(IDomainAnnouncer announcer)
        {
            _announcer = announcer;
        }

        public void PriceDiscountApplied(PriceDiscountAppliedContext context)
        {
            _announcer.Announce(context);
        }
    }
~~~~

* Domain contexts:
~~~~
    public class PriceDiscountAppliedContext : IDomainContext
    {
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal PriceDiscount { get; set; }
    }
~~~~

* Domain announcers:
~~~~
    public class ConsoleDomainAnnouncer : IDomainAnnouncer
    {
        public void Announce(IDomainContext context)
        {
            Console.WriteLine($"Announcing {context.GetType()}");
        }
    }
~~~~

* Domain monitors:
~~~~
    public class LoggingMonitor : IDomainMonitor
    {
        private readonly ILogger _logger;

        public LoggingMonitor(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(IDomainContext context)
        {
            _logger.Log($"Logging {context.GetType()}");
        }
    }
~~~~

## Thanks
* [Probe](https://thenounproject.com/term/probe/2920418/) icon by [Ayub Irawan](https://thenounproject.com/ayub12/) from [The Noun Project](https://thenounproject.com)
