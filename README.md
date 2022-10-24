# dynipmon
pronounced /die-nip-mawn/

ip address monitor for dynamic addresses

dynipmon checks once every minute to find out what the public ip address is for the system it's running on

it then overwrites the public ip to a file specified in the config file ./dynipmon.cfg

if no file is specified or the config file doesn't exist, it will create a new config file pointing at the default filename

the default filename is ./public-ip.txt

it can take any filename but if it doesn't have permisions to edit the file, the overwrite will fail

failures and other errors will be reported in ./dim.log

past ip addresses will also be logged in ./dim.log

dynipmon will append the contents of the public-ip file to the log before overwrite occurs

you can use the "skip logging" option with the argument 's' to redirect the ip address to standard output instead of recording it to a file

you can use the "only once" option with the argument 'o' to redirect the ip address to standard output instead of recording it to a file while also only performing the check one time instead of checking repeatedly (this option is intended for data pipelines)

