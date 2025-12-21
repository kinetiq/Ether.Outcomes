What is Outcome.NET?
==============
Outcome is the ultimate result wrapper! It's great for those awkward moments when you need to return a value, but you might also need to return a list of validation messages, warnings, or a success bit.

It's a fluent, expressive, easy-to-learn spin on the <a href="http://martinfowler.com/dslCatalog/notification.html">Notification pattern</a>, with a few careful tweaks.

Outcome is particularly useful in MVC projects that do a lot of AJAX calls. If you serialize Outcome objects back to the client, you end up with a standard interface for most of your callbacks, and that opens doors for reuse on the JavaScript side.

How can I get started?
==============

Check out the <a href="https://github.com/kinetiq/Ether.Outcomes/wiki/Getting-started">getting started guide</a>.

Where can I get it?
==============

First, <a href="http://docs.nuget.org/docs/start-here/installing-nuget">install NuGet</a>. Then, install Outcome.NET from the package manager console:

>PM> Install-Package Ether.Outcomes

Outcome.NET is Copyright © 2014 Brian MacKay, <a href="getkinetiq.com">Kinetiq</a>, and other contributors under the MIT license.

Support This Project
==============

If you find Outcome.NET useful, consider buying me a coffee!

<a href="https://buymeacoffee.com/kinetiq" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>
