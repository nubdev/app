configs ={
  :git => {
    :user => '20121001chicago',
    :remotes => %w/madhatter84gn nubdev jeffsnow jreynolds6 misterken mkrawitz/,
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
