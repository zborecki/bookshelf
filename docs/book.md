# Book

## Overview
Book is one of the main domain entities in the library system. It represents a catalog entry, not a physical copy located in the library.  

Separating a book from a copy is a key element of the data model. Book stores information describing a specific title, while copy represents its physical instance in the library.

## Responsibility
The entity is responsible for storing basic catalog information about a book:
- identifying the book
- storing the title
- storing the ISBN
- associating the book with its authors
- associating the book with its physical copies

Book is not responsible for:
- the current status of a physical copy
- information about who has a copy
- loan history
- the borrowing or returning process

This information belongs to Copy and Loan, respectively.

## Properties and constraints
| Property  | Type                  | Required | Constraints                      | Description                                                     |
| --------- | --------------------- | -------- | -------------------------------- | --------------------------------------------------------------- |
| `Id`      | `int`                 |      Yes | Primary key, unique              | Unique identifier of the book.                                  |
| `Title`   | `string`              |      Yes | Maximum length: `255`, not empty | Title of the publication.                                       |
| `ISBN`    | `string`              |      Yes | Maximum length: `20`, unique     | International Standard Book Number identifying the publication. |
| `Authors` | `ICollection<Author>` |      Yes | Many-to-many relationship        | Authors associated with the book.                               |
| `Copies`  | `ICollection<Copy>`   |      Yes | One-to-many relationship         | Physical copies belonging to the book.                          |

## Lifecycle
The book represents a publication in the library catalog and remains in the catalog independently of the physical copies associated with it. A typical lifecycle starts when a new book is added to the catalog. At this stage, the system stores the book's basic information, such as its title and ISBN, and associates the book with one or more authors. Physical copies can then be added and linked to the book. Once copies exist, their individual lifecycle is managed independently from the Book entity. A copy can change its status, for example from Available to Borrowed, and later back to Available. These state changes do not modify the lifecycle of the book itself.  

A book therefore remains a catalog entry even when all of its copies are currently borrowed, unavailable, or temporarily removed from circulation. The Book entity describes what the publication is, while the Copy entity represents the physical resources that can be borrowed.  

When a book is no longer intended to be part of the active catalog, its removal must take into account the copies and loan history associated with it. Depending on the business requirements, the system may prevent deletion when copies or historical loans exist, use soft deletion, or archive the book instead of physically removing it from the database.  

```
Book created → Authors assigned → Copies added → Copies change availability → Book remains in catalog
```
