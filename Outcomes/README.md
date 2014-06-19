What is Outcome.NET?
==============

Outcome.NET is a fluent wrapper for .NET that eliminates plumbing code around failure-prone functions.

Ever write a method that could fail intermittently, like a call to a particularly flaky web service?

Typically, you handle this one of three ways: by throwing/catching exceptions, by tacking boilderplate code onto your result with metadata to indicate success or failure, or by wrapping the result in another object. 

All of these work, but they're plumbing, and that's wasteful. Outcome.NET takes the third approach and extends it, providing an expressive, fluent wrapper that just works. 

How can I get started?
==============

Check out the <a href="https://github.com/kinetiq/Ether.Outcomes/wiki/Getting-started">getting started guide</a>.


Where can I get it?
==============

First, <a href="http://docs.nuget.org/docs/start-here/installing-nuget">install NuGet</a>. Then, install Outcome.NET from the package manager console:

>PM> Install-Package Ether.Outcomes

Outcome.NET is Copyright © 2014 Brian MacKay, <a href="getkinetiq.com">Kinetiq</a>, and other contributors under the MIT license.
