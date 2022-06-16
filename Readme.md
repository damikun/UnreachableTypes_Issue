
## Description

Schema issue in case the server option `options.RemoveUnreachableTypes = true;` is enabled. 

- BCP is unable to fetch schema without showing error only logs exception to console.

```json
Uncaught (in promise) Error: Invalid or incomplete schema, unknown type: Int. Ensure that a full introspection query is used in order to build a client schema.
    at f (document-scheduler.0f28a64b.worker.js:2:730451)
    at p (document-scheduler.0f28a64b.worker.js:2:730322)
    at p (document-scheduler.0f28a64b.worker.js:2:730177)
    at D (document-scheduler.0f28a64b.worker.js:2:731698)
    at Mn (document-scheduler.0f28a64b.worker.js:2:687946)
    at g (document-scheduler.0f28a64b.worker.js:2:731641)
    at document-scheduler.0f28a64b.worker.js:2:729730
    at Array.map (<anonymous>)
    at ci (document-scheduler.0f28a64b.worker.js:2:729369)
    at document-scheduler.0f28a64b.worker.js:2:732465
```
## Reproduction

1) Preparation
   
 Make sure:
- you alwais clear website data in dev tool between changes BCP presist some state..
- make sure you disable caching in network view of dev tools
- do not use hot-reload restart server between changes it is chane in startup config.
  

By repo `setup` the error shoud appear since `options.RemoveUnreachableTypes = true;` 

1) disable option to `false`
2) restart server (do not use just hot reload)
3) clear bcp website data
4) Navigate to bcp default url
5) Schema will be loaded


![Tux, the Linux mascot](/img/A.png)


Reset website data + in network tab disable cache...
 ![Tux, the Linux mascot](/img/B.png)