#Project Conventions


1. All tests for a component live in a file named [Component]Specs.cs.

2. All micro configuration files will live under the source/config folder, with an .erb extension following their real extension. Templated values will be expanded based on machine specific settings.

3. All stubs:
  * Will live under a stubs folder, at the level of the namespace where the contract lives.
  * Name of the stub will follow this standard Stub[Component]

4. Front Controller Conventions:

  1. 1 Logical view per report model
  2. 1 Command Per Feature
