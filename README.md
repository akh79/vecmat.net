# vecmat.net
A minimal pure C# library for small fixed-size vectors/matrices and affine transformations.

I started this library because when transitioning from C++ to C# I was disappointed by the absence of this kind of library. Recently I discovered a similar pure C# library **Sharp3D.Math** (https://github.com/ekampf/Sharp3D.Math). So **vecmat.net** is to be considered a learning project. I don't use any fancy language constructs, no generics (only double for now). I decided to stay with .Net Framework which put limitations on C# language features.

Probably, two things are worth mentioning:

- Affine transformation cannot be created from an arbitrary matrix, nor can its data members be directly manipulated. Affine transformation can be created by geometric operations like translation, rotation, scaling, shearing.
- There are two operators * and ^ to apply an affine transformation to a vector (operator *) or to a point (operator ^). This allows avoiding explicit *point* / *vector* dichotomy and work everywhere with basic *vector*.

​    For unit testing I use xUnit framework.
