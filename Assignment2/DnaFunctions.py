def get_length(dna):
    ''' (str) -> int

    Return the length of the DNA sequence dna.

    >>> get_length('ATCGAT')
    6
    >>> get_length('ATCG')
    4
    '''
    return len(dna)

def is_longer(dna1, dna2):
    ''' (str, str) -> bool

    Return True if and only if DNA sequence dna1 is longer than DNA sequence
    dna2.

    >>> is_longer('ATCG', 'AT')
    True
    >>> is_longer('ATCG', 'ATCGGA')
    False
    '''
    return len(dna1) > len(dna2)

def count_nucleotides(dna, nucleotide):
    ''' (str, str) -> int

    Return the number of occurrences of nucleotide in the DNA sequence dna.

    >>> count_nucleotides('ATCGGC', 'G')
    2
    >>> count_nucleotides('ATCTA', 'G')
    0
    '''
    return dna.count(nucleotide)

def contains_sequence(dna1, dna2):
    ''' (str, str) -> bool

    Return True if and only if DNA sequence dna2 occurs in the DNA sequence
    dna1.

    >>> contains_sequence('ATCGGC', 'GG')
    True
    >>> contains_sequence('ATCGGC', 'GT')
    False
    
    '''
    return dna2 in dna1

def is_valid_sequence(dna):
    ''' (str) -> bool

    Return True if and only if the DNA sequence is valid,
    that is, it contains no characters other than 'A', 'T', 'C' and 'G'. 

    >>> is_valid_sequence('ATCGGC')
    True
    >>> is_valid_sequence('ATCGGS')
    False
    '''
    nucleotideCount = 0
    nucleotides = ['A', 'T', 'C', 'G']

    for nucleotide in nucleotides:
        nucleotideCount = nucleotideCount + dna.count(nucleotide)

    return len(dna) <= nucleotideCount

def insert_sequence(dna, input, index):
    ''' (str, str, int) -> str

    Return the DNA sequence obtained by inserting the second DNA 
    sequence into the first DNA sequence at the given index.

    >>> insert_sequence('CCGG', 'AT', 2)
    CCATGG
    '''
    return dna[:index] + input + dna[index:]

def get_compliment(nucleotide):
    ''' (str) -> str

    Return the nucleotide's compliment. 

    >>> get_compliment('A')
    T
    >>> get_compliment('C')
    G
    >>> get_compliment('G')
    C
    '''
    ta = ['T', 'A']
    cg = ['C', 'G']

    if(nucleotide in ta):
        ta.remove(nucleotide)
        return ta[0]

    if(nucleotide in cg):
        cg.remove(nucleotide)
        return cg[0]

def get_complimentary_sequence():
    ''' (str) -> str

    Return the sequence's compliment. 

    >>> get_compliment('ACGTACG')
    TGCATGC
    '''
    