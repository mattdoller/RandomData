RandomData
==========

This project is a simple .net port of the uber-useful ruby gem, [random_data](https://github.com/tomharris/random_data).  This project is useful for generating random test data, such as names, addresses, phone numbers, basic text, and more.

Building
========

The `default.ps1` script is a Psake build file which contains several tasks for retrieving project dependencies, compiling, testing, and building releases.

To compile the project:

    > Invoke-Psake Compile

To run all tests:

    > Invoke-Psake Test

To build a nuget package:

    > Invoke-Psake Release

All of these tasks will invoke any necessary dependent tasks (i.e., building a package will run all unit tests, which in turn will compile the project).

Usage
=====

All of the functionality of this project is exposed through a single static class, `Randomized`.  Some example method calls:

## Names ##
    Randomized.Names.FirstName();
    Randomized.Names.FirstNameMale();
    Randomized.Names.FirstNameFemale();
    Randomized.Names.LastName();
    Randomized.Names.FullName();
    Randomized.Names.CompanyName();

## contact info ##
    Randomized.Contacts.Phone();
    Randomized.Contacts.InternationalPhone();
    Randomized.Contacts.Email();

## addresses and locations ##
    Randomized.Locations.City();
    Randomized.Locations.Country();
    Randomized.ZipCode();
    Randomized.PostalCode();
    Randomized.PostalCode(PostalCodeFormat.UnitedKingdom);

## urls and ip addresses ##
    Randomized.Net.Url();
    Randomized.Net.Url(UrlType.DomainOnly);
    Randomized.Net.Url(UrlType.DomainPathAndPage);
    Randomized.Net.IPv4();
    Randomized.Net.IPv6();

## dates ##
    Randomized.Dates.DateBetween(start, end);
    
## text ##
    Randomized.Text.Alphanumeric(16, Case.Upper);
    Randomized.Text.Numeric(8);
    Randomized.Text.Alpha(16);
    Randomized.Text.Hexadecimal(16, Case.Lower);
    Randomized.Text.Sentences(5);
    Randomized.Text.Paragraphs(5);

Contact
=======
Comments, suggestions, bug reports, and pull requests always welcome :) mattdoller@gmail.com

Special Thanks
==============
* Much thanks to Mike Subelsky for his [random_data](https://github.com/tomharris/random_data) gem
* Thanks to Ayende Rahien - parts of `default.ps1` and the Psake extensions file in this project were based off the build scripts in his [Rhino-Mocks](https://github.com/ayende/rhino-mocks) project.

Copyright
=========
Copyright (c) 2014 Matt Doller (mattdoller@gmail.com), released under the MIT license.