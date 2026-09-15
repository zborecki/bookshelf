# Book - Data model

## Overview
Book is one of the main domain entities in the library system. It represents a catalog entry, not a physical copy located in the library.  

Separating a book from a copy is a key element of the data model. Book stores information describing a specific title, while copy represents its physical instance in the library.