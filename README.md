What is Outcome.NET?
==============

Outcome.NET is a fluent wrapper for .NET that eliminates plumbing code around failure-prone functions.

Ever write a method that could fail unexpectedly, like a call out to a web service that you don't fully trust?

It would be great to just return the expected result, but instead you end up either using exceptions or writing wrappers, essentially plumbing, to handle cases where the resource is unavailable or does something erratic. 

Outcome.NET's replaces that plumbing code with simple, expressive calls that just work.

How can I get started?
==============

Check out the <a href="https://github.com/kinetiq/Ether.Outcomes/wiki/Getting-started">getting started guide</a>.


Where can I get it?
==============

First, <a href="http://docs.nuget.org/docs/start-here/installing-nuget">install NuGet</a>. Then, install Outcome.NET from the package manager console:

>PM> Install-Package Ether.Outcomes

Outcome.NET is Copyright © 2014 Brian MacKay, <a href="getkinetiq.com">Kinetiq</a>, and other contributors under the MIT license.
