# MKata
Worked on this by doing the following:
1) Read the requirements
2) Highlighted what I broke down from the requirements which are the comments in the Unit test file
3) Seperated the requirements into 2 different functionalities which are, ability to update cart, and ability to checkout which may or may not include discounted items
4) This made me break down my tests into 3 different test cases which are showing in the RepositoryTests.cs
5) Since an interface isnt needed for the purpose of this test, I am testing the Repository directly
6) I am using the Repository Pattern for data access
6) This repository has been abstracted, meaning I am using the interface because the concrete class is only provided static data, so when we need to expand this to use a real database, we can just create another concrete implementation of IDataRepository
7) I also created a way to apply discount, this has been abstracted out using the Strategy Pattern, meaning if one day we want to apply discount in anothe way, all we have to do is create another concrete implementation of the IDiscountStrategy which will then be injected into the Repository class we choose to use.

I Followed the concept of Red, Green, Refactor in this test.

I can discuss futher during our call if you have any questions. 
