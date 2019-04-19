// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Text.CaseFolding
{
    /// <summary>
    /// Simple case folding methods.
    /// </summary>
    public static partial class SimpleCaseFolding

    {
        private static readonly char[] MapBelow5FF =
        {
        //         0             1             2             3             4             5             6             7             8             9             a             b             c             d             e             f
            (char)0x0000, (char)0x0001, (char)0x0002, (char)0x0003, (char)0x0004, (char)0x0005, (char)0x0006, (char)0x0007, (char)0x0008, (char)0x0009, (char)0x000a, (char)0x000b, (char)0x000c, (char)0x000d, (char)0x000e, (char)0x000f,  // 0000 .. 000f
            (char)0x0010, (char)0x0011, (char)0x0012, (char)0x0013, (char)0x0014, (char)0x0015, (char)0x0016, (char)0x0017, (char)0x0018, (char)0x0019, (char)0x001a, (char)0x001b, (char)0x001c, (char)0x001d, (char)0x001e, (char)0x001f,  // 0010 .. 001f
            (char)0x0020, (char)0x0021, (char)0x0022, (char)0x0023, (char)0x0024, (char)0x0025, (char)0x0026, (char)0x0027, (char)0x0028, (char)0x0029, (char)0x002a, (char)0x002b, (char)0x002c, (char)0x002d, (char)0x002e, (char)0x002f,  // 0020 .. 002f
            (char)0x0030, (char)0x0031, (char)0x0032, (char)0x0033, (char)0x0034, (char)0x0035, (char)0x0036, (char)0x0037, (char)0x0038, (char)0x0039, (char)0x003a, (char)0x003b, (char)0x003c, (char)0x003d, (char)0x003e, (char)0x003f,  // 0030 .. 003f
            (char)0x0040, (char)0x0061, (char)0x0062, (char)0x0063, (char)0x0064, (char)0x0065, (char)0x0066, (char)0x0067, (char)0x0068, (char)0x0069, (char)0x006a, (char)0x006b, (char)0x006c, (char)0x006d, (char)0x006e, (char)0x006f,  // 0040 .. 004f
            (char)0x0070, (char)0x0071, (char)0x0072, (char)0x0073, (char)0x0074, (char)0x0075, (char)0x0076, (char)0x0077, (char)0x0078, (char)0x0079, (char)0x007a, (char)0x005b, (char)0x005c, (char)0x005d, (char)0x005e, (char)0x005f,  // 0050 .. 005f
            (char)0x0060, (char)0x0061, (char)0x0062, (char)0x0063, (char)0x0064, (char)0x0065, (char)0x0066, (char)0x0067, (char)0x0068, (char)0x0069, (char)0x006a, (char)0x006b, (char)0x006c, (char)0x006d, (char)0x006e, (char)0x006f,  // 0060 .. 006f
            (char)0x0070, (char)0x0071, (char)0x0072, (char)0x0073, (char)0x0074, (char)0x0075, (char)0x0076, (char)0x0077, (char)0x0078, (char)0x0079, (char)0x007a, (char)0x007b, (char)0x007c, (char)0x007d, (char)0x007e, (char)0x007f,  // 0070 .. 007f
            (char)0x0080, (char)0x0081, (char)0x0082, (char)0x0083, (char)0x0084, (char)0x0085, (char)0x0086, (char)0x0087, (char)0x0088, (char)0x0089, (char)0x008a, (char)0x008b, (char)0x008c, (char)0x008d, (char)0x008e, (char)0x008f,  // 0080 .. 008f
            (char)0x0090, (char)0x0091, (char)0x0092, (char)0x0093, (char)0x0094, (char)0x0095, (char)0x0096, (char)0x0097, (char)0x0098, (char)0x0099, (char)0x009a, (char)0x009b, (char)0x009c, (char)0x009d, (char)0x009e, (char)0x009f,  // 0090 .. 009f
            (char)0x00a0, (char)0x00a1, (char)0x00a2, (char)0x00a3, (char)0x00a4, (char)0x00a5, (char)0x00a6, (char)0x00a7, (char)0x00a8, (char)0x00a9, (char)0x00aa, (char)0x00ab, (char)0x00ac, (char)0x00ad, (char)0x00ae, (char)0x00af,  // 00a0 .. 00af
            (char)0x00b0, (char)0x00b1, (char)0x00b2, (char)0x00b3, (char)0x00b4, (char)0x03bc, (char)0x00b6, (char)0x00b7, (char)0x00b8, (char)0x00b9, (char)0x00ba, (char)0x00bb, (char)0x00bc, (char)0x00bd, (char)0x00be, (char)0x00bf,  // 00b0 .. 00bf
            (char)0x00e0, (char)0x00e1, (char)0x00e2, (char)0x00e3, (char)0x00e4, (char)0x00e5, (char)0x00e6, (char)0x00e7, (char)0x00e8, (char)0x00e9, (char)0x00ea, (char)0x00eb, (char)0x00ec, (char)0x00ed, (char)0x00ee, (char)0x00ef,  // 00c0 .. 00cf
            (char)0x00f0, (char)0x00f1, (char)0x00f2, (char)0x00f3, (char)0x00f4, (char)0x00f5, (char)0x00f6, (char)0x00d7, (char)0x00f8, (char)0x00f9, (char)0x00fa, (char)0x00fb, (char)0x00fc, (char)0x00fd, (char)0x00fe, (char)0x00df,  // 00d0 .. 00df
            (char)0x00e0, (char)0x00e1, (char)0x00e2, (char)0x00e3, (char)0x00e4, (char)0x00e5, (char)0x00e6, (char)0x00e7, (char)0x00e8, (char)0x00e9, (char)0x00ea, (char)0x00eb, (char)0x00ec, (char)0x00ed, (char)0x00ee, (char)0x00ef,  // 00e0 .. 00ef
            (char)0x00f0, (char)0x00f1, (char)0x00f2, (char)0x00f3, (char)0x00f4, (char)0x00f5, (char)0x00f6, (char)0x00f7, (char)0x00f8, (char)0x00f9, (char)0x00fa, (char)0x00fb, (char)0x00fc, (char)0x00fd, (char)0x00fe, (char)0x00ff,  // 00f0 .. 00ff
            (char)0x0101, (char)0x0101, (char)0x0103, (char)0x0103, (char)0x0105, (char)0x0105, (char)0x0107, (char)0x0107, (char)0x0109, (char)0x0109, (char)0x010b, (char)0x010b, (char)0x010d, (char)0x010d, (char)0x010f, (char)0x010f,  // 0100 .. 010f
            (char)0x0111, (char)0x0111, (char)0x0113, (char)0x0113, (char)0x0115, (char)0x0115, (char)0x0117, (char)0x0117, (char)0x0119, (char)0x0119, (char)0x011b, (char)0x011b, (char)0x011d, (char)0x011d, (char)0x011f, (char)0x011f,  // 0110 .. 011f
            (char)0x0121, (char)0x0121, (char)0x0123, (char)0x0123, (char)0x0125, (char)0x0125, (char)0x0127, (char)0x0127, (char)0x0129, (char)0x0129, (char)0x012b, (char)0x012b, (char)0x012d, (char)0x012d, (char)0x012f, (char)0x012f,  // 0120 .. 012f
            (char)0x0130, (char)0x0131, (char)0x0133, (char)0x0133, (char)0x0135, (char)0x0135, (char)0x0137, (char)0x0137, (char)0x0138, (char)0x013a, (char)0x013a, (char)0x013c, (char)0x013c, (char)0x013e, (char)0x013e, (char)0x0140,  // 0130 .. 013f
            (char)0x0140, (char)0x0142, (char)0x0142, (char)0x0144, (char)0x0144, (char)0x0146, (char)0x0146, (char)0x0148, (char)0x0148, (char)0x0149, (char)0x014b, (char)0x014b, (char)0x014d, (char)0x014d, (char)0x014f, (char)0x014f,  // 0140 .. 014f
            (char)0x0151, (char)0x0151, (char)0x0153, (char)0x0153, (char)0x0155, (char)0x0155, (char)0x0157, (char)0x0157, (char)0x0159, (char)0x0159, (char)0x015b, (char)0x015b, (char)0x015d, (char)0x015d, (char)0x015f, (char)0x015f,  // 0150 .. 015f
            (char)0x0161, (char)0x0161, (char)0x0163, (char)0x0163, (char)0x0165, (char)0x0165, (char)0x0167, (char)0x0167, (char)0x0169, (char)0x0169, (char)0x016b, (char)0x016b, (char)0x016d, (char)0x016d, (char)0x016f, (char)0x016f,  // 0160 .. 016f
            (char)0x0171, (char)0x0171, (char)0x0173, (char)0x0173, (char)0x0175, (char)0x0175, (char)0x0177, (char)0x0177, (char)0x00ff, (char)0x017a, (char)0x017a, (char)0x017c, (char)0x017c, (char)0x017e, (char)0x017e, (char)0x0073,  // 0170 .. 017f
            (char)0x0180, (char)0x0253, (char)0x0183, (char)0x0183, (char)0x0185, (char)0x0185, (char)0x0254, (char)0x0188, (char)0x0188, (char)0x0256, (char)0x0257, (char)0x018c, (char)0x018c, (char)0x018d, (char)0x01dd, (char)0x0259,  // 0180 .. 018f
            (char)0x025b, (char)0x0192, (char)0x0192, (char)0x0260, (char)0x0263, (char)0x0195, (char)0x0269, (char)0x0268, (char)0x0199, (char)0x0199, (char)0x019a, (char)0x019b, (char)0x026f, (char)0x0272, (char)0x019e, (char)0x0275,  // 0190 .. 019f
            (char)0x01a1, (char)0x01a1, (char)0x01a3, (char)0x01a3, (char)0x01a5, (char)0x01a5, (char)0x0280, (char)0x01a8, (char)0x01a8, (char)0x0283, (char)0x01aa, (char)0x01ab, (char)0x01ad, (char)0x01ad, (char)0x0288, (char)0x01b0,  // 01a0 .. 01af
            (char)0x01b0, (char)0x028a, (char)0x028b, (char)0x01b4, (char)0x01b4, (char)0x01b6, (char)0x01b6, (char)0x0292, (char)0x01b9, (char)0x01b9, (char)0x01ba, (char)0x01bb, (char)0x01bd, (char)0x01bd, (char)0x01be, (char)0x01bf,  // 01b0 .. 01bf
            (char)0x01c0, (char)0x01c1, (char)0x01c2, (char)0x01c3, (char)0x01c6, (char)0x01c6, (char)0x01c6, (char)0x01c9, (char)0x01c9, (char)0x01c9, (char)0x01cc, (char)0x01cc, (char)0x01cc, (char)0x01ce, (char)0x01ce, (char)0x01d0,  // 01c0 .. 01cf
            (char)0x01d0, (char)0x01d2, (char)0x01d2, (char)0x01d4, (char)0x01d4, (char)0x01d6, (char)0x01d6, (char)0x01d8, (char)0x01d8, (char)0x01da, (char)0x01da, (char)0x01dc, (char)0x01dc, (char)0x01dd, (char)0x01df, (char)0x01df,  // 01d0 .. 01df
            (char)0x01e1, (char)0x01e1, (char)0x01e3, (char)0x01e3, (char)0x01e5, (char)0x01e5, (char)0x01e7, (char)0x01e7, (char)0x01e9, (char)0x01e9, (char)0x01eb, (char)0x01eb, (char)0x01ed, (char)0x01ed, (char)0x01ef, (char)0x01ef,  // 01e0 .. 01ef
            (char)0x01f0, (char)0x01f3, (char)0x01f3, (char)0x01f3, (char)0x01f5, (char)0x01f5, (char)0x0195, (char)0x01bf, (char)0x01f9, (char)0x01f9, (char)0x01fb, (char)0x01fb, (char)0x01fd, (char)0x01fd, (char)0x01ff, (char)0x01ff,  // 01f0 .. 01ff
            (char)0x0201, (char)0x0201, (char)0x0203, (char)0x0203, (char)0x0205, (char)0x0205, (char)0x0207, (char)0x0207, (char)0x0209, (char)0x0209, (char)0x020b, (char)0x020b, (char)0x020d, (char)0x020d, (char)0x020f, (char)0x020f,  // 0200 .. 020f
            (char)0x0211, (char)0x0211, (char)0x0213, (char)0x0213, (char)0x0215, (char)0x0215, (char)0x0217, (char)0x0217, (char)0x0219, (char)0x0219, (char)0x021b, (char)0x021b, (char)0x021d, (char)0x021d, (char)0x021f, (char)0x021f,  // 0210 .. 021f
            (char)0x019e, (char)0x0221, (char)0x0223, (char)0x0223, (char)0x0225, (char)0x0225, (char)0x0227, (char)0x0227, (char)0x0229, (char)0x0229, (char)0x022b, (char)0x022b, (char)0x022d, (char)0x022d, (char)0x022f, (char)0x022f,  // 0220 .. 022f
            (char)0x0231, (char)0x0231, (char)0x0233, (char)0x0233, (char)0x0234, (char)0x0235, (char)0x0236, (char)0x0237, (char)0x0238, (char)0x0239, (char)0x2c65, (char)0x023c, (char)0x023c, (char)0x019a, (char)0x2c66, (char)0x023f,  // 0230 .. 023f
            (char)0x0240, (char)0x0242, (char)0x0242, (char)0x0180, (char)0x0289, (char)0x028c, (char)0x0247, (char)0x0247, (char)0x0249, (char)0x0249, (char)0x024b, (char)0x024b, (char)0x024d, (char)0x024d, (char)0x024f, (char)0x024f,  // 0240 .. 024f
            (char)0x0250, (char)0x0251, (char)0x0252, (char)0x0253, (char)0x0254, (char)0x0255, (char)0x0256, (char)0x0257, (char)0x0258, (char)0x0259, (char)0x025a, (char)0x025b, (char)0x025c, (char)0x025d, (char)0x025e, (char)0x025f,  // 0250 .. 025f
            (char)0x0260, (char)0x0261, (char)0x0262, (char)0x0263, (char)0x0264, (char)0x0265, (char)0x0266, (char)0x0267, (char)0x0268, (char)0x0269, (char)0x026a, (char)0x026b, (char)0x026c, (char)0x026d, (char)0x026e, (char)0x026f,  // 0260 .. 026f
            (char)0x0270, (char)0x0271, (char)0x0272, (char)0x0273, (char)0x0274, (char)0x0275, (char)0x0276, (char)0x0277, (char)0x0278, (char)0x0279, (char)0x027a, (char)0x027b, (char)0x027c, (char)0x027d, (char)0x027e, (char)0x027f,  // 0270 .. 027f
            (char)0x0280, (char)0x0281, (char)0x0282, (char)0x0283, (char)0x0284, (char)0x0285, (char)0x0286, (char)0x0287, (char)0x0288, (char)0x0289, (char)0x028a, (char)0x028b, (char)0x028c, (char)0x028d, (char)0x028e, (char)0x028f,  // 0280 .. 028f
            (char)0x0290, (char)0x0291, (char)0x0292, (char)0x0293, (char)0x0294, (char)0x0295, (char)0x0296, (char)0x0297, (char)0x0298, (char)0x0299, (char)0x029a, (char)0x029b, (char)0x029c, (char)0x029d, (char)0x029e, (char)0x029f,  // 0290 .. 029f
            (char)0x02a0, (char)0x02a1, (char)0x02a2, (char)0x02a3, (char)0x02a4, (char)0x02a5, (char)0x02a6, (char)0x02a7, (char)0x02a8, (char)0x02a9, (char)0x02aa, (char)0x02ab, (char)0x02ac, (char)0x02ad, (char)0x02ae, (char)0x02af,  // 02a0 .. 02af
            (char)0x02b0, (char)0x02b1, (char)0x02b2, (char)0x02b3, (char)0x02b4, (char)0x02b5, (char)0x02b6, (char)0x02b7, (char)0x02b8, (char)0x02b9, (char)0x02ba, (char)0x02bb, (char)0x02bc, (char)0x02bd, (char)0x02be, (char)0x02bf,  // 02b0 .. 02bf
            (char)0x02c0, (char)0x02c1, (char)0x02c2, (char)0x02c3, (char)0x02c4, (char)0x02c5, (char)0x02c6, (char)0x02c7, (char)0x02c8, (char)0x02c9, (char)0x02ca, (char)0x02cb, (char)0x02cc, (char)0x02cd, (char)0x02ce, (char)0x02cf,  // 02c0 .. 02cf
            (char)0x02d0, (char)0x02d1, (char)0x02d2, (char)0x02d3, (char)0x02d4, (char)0x02d5, (char)0x02d6, (char)0x02d7, (char)0x02d8, (char)0x02d9, (char)0x02da, (char)0x02db, (char)0x02dc, (char)0x02dd, (char)0x02de, (char)0x02df,  // 02d0 .. 02df
            (char)0x02e0, (char)0x02e1, (char)0x02e2, (char)0x02e3, (char)0x02e4, (char)0x02e5, (char)0x02e6, (char)0x02e7, (char)0x02e8, (char)0x02e9, (char)0x02ea, (char)0x02eb, (char)0x02ec, (char)0x02ed, (char)0x02ee, (char)0x02ef,  // 02e0 .. 02ef
            (char)0x02f0, (char)0x02f1, (char)0x02f2, (char)0x02f3, (char)0x02f4, (char)0x02f5, (char)0x02f6, (char)0x02f7, (char)0x02f8, (char)0x02f9, (char)0x02fa, (char)0x02fb, (char)0x02fc, (char)0x02fd, (char)0x02fe, (char)0x02ff,  // 02f0 .. 02ff
            (char)0x0300, (char)0x0301, (char)0x0302, (char)0x0303, (char)0x0304, (char)0x0305, (char)0x0306, (char)0x0307, (char)0x0308, (char)0x0309, (char)0x030a, (char)0x030b, (char)0x030c, (char)0x030d, (char)0x030e, (char)0x030f,  // 0300 .. 030f
            (char)0x0310, (char)0x0311, (char)0x0312, (char)0x0313, (char)0x0314, (char)0x0315, (char)0x0316, (char)0x0317, (char)0x0318, (char)0x0319, (char)0x031a, (char)0x031b, (char)0x031c, (char)0x031d, (char)0x031e, (char)0x031f,  // 0310 .. 031f
            (char)0x0320, (char)0x0321, (char)0x0322, (char)0x0323, (char)0x0324, (char)0x0325, (char)0x0326, (char)0x0327, (char)0x0328, (char)0x0329, (char)0x032a, (char)0x032b, (char)0x032c, (char)0x032d, (char)0x032e, (char)0x032f,  // 0320 .. 032f
            (char)0x0330, (char)0x0331, (char)0x0332, (char)0x0333, (char)0x0334, (char)0x0335, (char)0x0336, (char)0x0337, (char)0x0338, (char)0x0339, (char)0x033a, (char)0x033b, (char)0x033c, (char)0x033d, (char)0x033e, (char)0x033f,  // 0330 .. 033f
            (char)0x0340, (char)0x0341, (char)0x0342, (char)0x0343, (char)0x0344, (char)0x03b9, (char)0x0346, (char)0x0347, (char)0x0348, (char)0x0349, (char)0x034a, (char)0x034b, (char)0x034c, (char)0x034d, (char)0x034e, (char)0x034f,  // 0340 .. 034f
            (char)0x0350, (char)0x0351, (char)0x0352, (char)0x0353, (char)0x0354, (char)0x0355, (char)0x0356, (char)0x0357, (char)0x0358, (char)0x0359, (char)0x035a, (char)0x035b, (char)0x035c, (char)0x035d, (char)0x035e, (char)0x035f,  // 0350 .. 035f
            (char)0x0360, (char)0x0361, (char)0x0362, (char)0x0363, (char)0x0364, (char)0x0365, (char)0x0366, (char)0x0367, (char)0x0368, (char)0x0369, (char)0x036a, (char)0x036b, (char)0x036c, (char)0x036d, (char)0x036e, (char)0x036f,  // 0360 .. 036f
            (char)0x0371, (char)0x0371, (char)0x0373, (char)0x0373, (char)0x0374, (char)0x0375, (char)0x0377, (char)0x0377, (char)0x0378, (char)0x0379, (char)0x037a, (char)0x037b, (char)0x037c, (char)0x037d, (char)0x037e, (char)0x03f3,  // 0370 .. 037f
            (char)0x0380, (char)0x0381, (char)0x0382, (char)0x0383, (char)0x0384, (char)0x0385, (char)0x03ac, (char)0x0387, (char)0x03ad, (char)0x03ae, (char)0x03af, (char)0x038b, (char)0x03cc, (char)0x038d, (char)0x03cd, (char)0x03ce,  // 0380 .. 038f
            (char)0x0390, (char)0x03b1, (char)0x03b2, (char)0x03b3, (char)0x03b4, (char)0x03b5, (char)0x03b6, (char)0x03b7, (char)0x03b8, (char)0x03b9, (char)0x03ba, (char)0x03bb, (char)0x03bc, (char)0x03bd, (char)0x03be, (char)0x03bf,  // 0390 .. 039f
            (char)0x03c0, (char)0x03c1, (char)0x03a2, (char)0x03c3, (char)0x03c4, (char)0x03c5, (char)0x03c6, (char)0x03c7, (char)0x03c8, (char)0x03c9, (char)0x03ca, (char)0x03cb, (char)0x03ac, (char)0x03ad, (char)0x03ae, (char)0x03af,  // 03a0 .. 03af
            (char)0x03b0, (char)0x03b1, (char)0x03b2, (char)0x03b3, (char)0x03b4, (char)0x03b5, (char)0x03b6, (char)0x03b7, (char)0x03b8, (char)0x03b9, (char)0x03ba, (char)0x03bb, (char)0x03bc, (char)0x03bd, (char)0x03be, (char)0x03bf,  // 03b0 .. 03bf
            (char)0x03c0, (char)0x03c1, (char)0x03c3, (char)0x03c3, (char)0x03c4, (char)0x03c5, (char)0x03c6, (char)0x03c7, (char)0x03c8, (char)0x03c9, (char)0x03ca, (char)0x03cb, (char)0x03cc, (char)0x03cd, (char)0x03ce, (char)0x03d7,  // 03c0 .. 03cf
            (char)0x03b2, (char)0x03b8, (char)0x03d2, (char)0x03d3, (char)0x03d4, (char)0x03c6, (char)0x03c0, (char)0x03d7, (char)0x03d9, (char)0x03d9, (char)0x03db, (char)0x03db, (char)0x03dd, (char)0x03dd, (char)0x03df, (char)0x03df,  // 03d0 .. 03df
            (char)0x03e1, (char)0x03e1, (char)0x03e3, (char)0x03e3, (char)0x03e5, (char)0x03e5, (char)0x03e7, (char)0x03e7, (char)0x03e9, (char)0x03e9, (char)0x03eb, (char)0x03eb, (char)0x03ed, (char)0x03ed, (char)0x03ef, (char)0x03ef,  // 03e0 .. 03ef
            (char)0x03ba, (char)0x03c1, (char)0x03f2, (char)0x03f3, (char)0x03b8, (char)0x03b5, (char)0x03f6, (char)0x03f8, (char)0x03f8, (char)0x03f2, (char)0x03fb, (char)0x03fb, (char)0x03fc, (char)0x037b, (char)0x037c, (char)0x037d,  // 03f0 .. 03ff
            (char)0x0450, (char)0x0451, (char)0x0452, (char)0x0453, (char)0x0454, (char)0x0455, (char)0x0456, (char)0x0457, (char)0x0458, (char)0x0459, (char)0x045a, (char)0x045b, (char)0x045c, (char)0x045d, (char)0x045e, (char)0x045f,  // 0400 .. 040f
            (char)0x0430, (char)0x0431, (char)0x0432, (char)0x0433, (char)0x0434, (char)0x0435, (char)0x0436, (char)0x0437, (char)0x0438, (char)0x0439, (char)0x043a, (char)0x043b, (char)0x043c, (char)0x043d, (char)0x043e, (char)0x043f,  // 0410 .. 041f
            (char)0x0440, (char)0x0441, (char)0x0442, (char)0x0443, (char)0x0444, (char)0x0445, (char)0x0446, (char)0x0447, (char)0x0448, (char)0x0449, (char)0x044a, (char)0x044b, (char)0x044c, (char)0x044d, (char)0x044e, (char)0x044f,  // 0420 .. 042f
            (char)0x0430, (char)0x0431, (char)0x0432, (char)0x0433, (char)0x0434, (char)0x0435, (char)0x0436, (char)0x0437, (char)0x0438, (char)0x0439, (char)0x043a, (char)0x043b, (char)0x043c, (char)0x043d, (char)0x043e, (char)0x043f,  // 0430 .. 043f
            (char)0x0440, (char)0x0441, (char)0x0442, (char)0x0443, (char)0x0444, (char)0x0445, (char)0x0446, (char)0x0447, (char)0x0448, (char)0x0449, (char)0x044a, (char)0x044b, (char)0x044c, (char)0x044d, (char)0x044e, (char)0x044f,  // 0440 .. 044f
            (char)0x0450, (char)0x0451, (char)0x0452, (char)0x0453, (char)0x0454, (char)0x0455, (char)0x0456, (char)0x0457, (char)0x0458, (char)0x0459, (char)0x045a, (char)0x045b, (char)0x045c, (char)0x045d, (char)0x045e, (char)0x045f,  // 0450 .. 045f
            (char)0x0461, (char)0x0461, (char)0x0463, (char)0x0463, (char)0x0465, (char)0x0465, (char)0x0467, (char)0x0467, (char)0x0469, (char)0x0469, (char)0x046b, (char)0x046b, (char)0x046d, (char)0x046d, (char)0x046f, (char)0x046f,  // 0460 .. 046f
            (char)0x0471, (char)0x0471, (char)0x0473, (char)0x0473, (char)0x0475, (char)0x0475, (char)0x0477, (char)0x0477, (char)0x0479, (char)0x0479, (char)0x047b, (char)0x047b, (char)0x047d, (char)0x047d, (char)0x047f, (char)0x047f,  // 0470 .. 047f
            (char)0x0481, (char)0x0481, (char)0x0482, (char)0x0483, (char)0x0484, (char)0x0485, (char)0x0486, (char)0x0487, (char)0x0488, (char)0x0489, (char)0x048b, (char)0x048b, (char)0x048d, (char)0x048d, (char)0x048f, (char)0x048f,  // 0480 .. 048f
            (char)0x0491, (char)0x0491, (char)0x0493, (char)0x0493, (char)0x0495, (char)0x0495, (char)0x0497, (char)0x0497, (char)0x0499, (char)0x0499, (char)0x049b, (char)0x049b, (char)0x049d, (char)0x049d, (char)0x049f, (char)0x049f,  // 0490 .. 049f
            (char)0x04a1, (char)0x04a1, (char)0x04a3, (char)0x04a3, (char)0x04a5, (char)0x04a5, (char)0x04a7, (char)0x04a7, (char)0x04a9, (char)0x04a9, (char)0x04ab, (char)0x04ab, (char)0x04ad, (char)0x04ad, (char)0x04af, (char)0x04af,  // 04a0 .. 04af
            (char)0x04b1, (char)0x04b1, (char)0x04b3, (char)0x04b3, (char)0x04b5, (char)0x04b5, (char)0x04b7, (char)0x04b7, (char)0x04b9, (char)0x04b9, (char)0x04bb, (char)0x04bb, (char)0x04bd, (char)0x04bd, (char)0x04bf, (char)0x04bf,  // 04b0 .. 04bf
            (char)0x04cf, (char)0x04c2, (char)0x04c2, (char)0x04c4, (char)0x04c4, (char)0x04c6, (char)0x04c6, (char)0x04c8, (char)0x04c8, (char)0x04ca, (char)0x04ca, (char)0x04cc, (char)0x04cc, (char)0x04ce, (char)0x04ce, (char)0x04cf,  // 04c0 .. 04cf
            (char)0x04d1, (char)0x04d1, (char)0x04d3, (char)0x04d3, (char)0x04d5, (char)0x04d5, (char)0x04d7, (char)0x04d7, (char)0x04d9, (char)0x04d9, (char)0x04db, (char)0x04db, (char)0x04dd, (char)0x04dd, (char)0x04df, (char)0x04df,  // 04d0 .. 04df
            (char)0x04e1, (char)0x04e1, (char)0x04e3, (char)0x04e3, (char)0x04e5, (char)0x04e5, (char)0x04e7, (char)0x04e7, (char)0x04e9, (char)0x04e9, (char)0x04eb, (char)0x04eb, (char)0x04ed, (char)0x04ed, (char)0x04ef, (char)0x04ef,  // 04e0 .. 04ef
            (char)0x04f1, (char)0x04f1, (char)0x04f3, (char)0x04f3, (char)0x04f5, (char)0x04f5, (char)0x04f7, (char)0x04f7, (char)0x04f9, (char)0x04f9, (char)0x04fb, (char)0x04fb, (char)0x04fd, (char)0x04fd, (char)0x04ff, (char)0x04ff,  // 04f0 .. 04ff
            (char)0x0501, (char)0x0501, (char)0x0503, (char)0x0503, (char)0x0505, (char)0x0505, (char)0x0507, (char)0x0507, (char)0x0509, (char)0x0509, (char)0x050b, (char)0x050b, (char)0x050d, (char)0x050d, (char)0x050f, (char)0x050f,  // 0500 .. 050f
            (char)0x0511, (char)0x0511, (char)0x0513, (char)0x0513, (char)0x0515, (char)0x0515, (char)0x0517, (char)0x0517, (char)0x0519, (char)0x0519, (char)0x051b, (char)0x051b, (char)0x051d, (char)0x051d, (char)0x051f, (char)0x051f,  // 0510 .. 051f
            (char)0x0521, (char)0x0521, (char)0x0523, (char)0x0523, (char)0x0525, (char)0x0525, (char)0x0527, (char)0x0527, (char)0x0529, (char)0x0529, (char)0x052b, (char)0x052b, (char)0x052d, (char)0x052d, (char)0x052f, (char)0x052f,  // 0520 .. 052f
            (char)0x0530, (char)0x0561, (char)0x0562, (char)0x0563, (char)0x0564, (char)0x0565, (char)0x0566, (char)0x0567, (char)0x0568, (char)0x0569, (char)0x056a, (char)0x056b, (char)0x056c, (char)0x056d, (char)0x056e, (char)0x056f,  // 0530 .. 053f
            (char)0x0570, (char)0x0571, (char)0x0572, (char)0x0573, (char)0x0574, (char)0x0575, (char)0x0576, (char)0x0577, (char)0x0578, (char)0x0579, (char)0x057a, (char)0x057b, (char)0x057c, (char)0x057d, (char)0x057e, (char)0x057f,  // 0540 .. 054f
            (char)0x0580, (char)0x0581, (char)0x0582, (char)0x0583, (char)0x0584, (char)0x0585, (char)0x0586, (char)0x0557, (char)0x0558, (char)0x0559, (char)0x055a, (char)0x055b, (char)0x055c, (char)0x055d, (char)0x055e, (char)0x055f,  // 0550 .. 055f
            (char)0x0560, (char)0x0561, (char)0x0562, (char)0x0563, (char)0x0564, (char)0x0565, (char)0x0566, (char)0x0567, (char)0x0568, (char)0x0569, (char)0x056a, (char)0x056b, (char)0x056c, (char)0x056d, (char)0x056e, (char)0x056f,  // 0560 .. 056f
            (char)0x0570, (char)0x0571, (char)0x0572, (char)0x0573, (char)0x0574, (char)0x0575, (char)0x0576, (char)0x0577, (char)0x0578, (char)0x0579, (char)0x057a, (char)0x057b, (char)0x057c, (char)0x057d, (char)0x057e, (char)0x057f,  // 0570 .. 057f
            (char)0x0580, (char)0x0581, (char)0x0582, (char)0x0583, (char)0x0584, (char)0x0585, (char)0x0586, (char)0x0587, (char)0x0588, (char)0x0589, (char)0x058a, (char)0x058b, (char)0x058c, (char)0x058d, (char)0x058e, (char)0x058f,  // 0580 .. 058f
            (char)0x0590, (char)0x0591, (char)0x0592, (char)0x0593, (char)0x0594, (char)0x0595, (char)0x0596, (char)0x0597, (char)0x0598, (char)0x0599, (char)0x059a, (char)0x059b, (char)0x059c, (char)0x059d, (char)0x059e, (char)0x059f,  // 0590 .. 059f
            (char)0x05a0, (char)0x05a1, (char)0x05a2, (char)0x05a3, (char)0x05a4, (char)0x05a5, (char)0x05a6, (char)0x05a7, (char)0x05a8, (char)0x05a9, (char)0x05aa, (char)0x05ab, (char)0x05ac, (char)0x05ad, (char)0x05ae, (char)0x05af,  // 05a0 .. 05af
            (char)0x05b0, (char)0x05b1, (char)0x05b2, (char)0x05b3, (char)0x05b4, (char)0x05b5, (char)0x05b6, (char)0x05b7, (char)0x05b8, (char)0x05b9, (char)0x05ba, (char)0x05bb, (char)0x05bc, (char)0x05bd, (char)0x05be, (char)0x05bf,  // 05b0 .. 05bf
            (char)0x05c0, (char)0x05c1, (char)0x05c2, (char)0x05c3, (char)0x05c4, (char)0x05c5, (char)0x05c6, (char)0x05c7, (char)0x05c8, (char)0x05c9, (char)0x05ca, (char)0x05cb, (char)0x05cc, (char)0x05cd, (char)0x05ce, (char)0x05cf,  // 05c0 .. 05cf
            (char)0x05d0, (char)0x05d1, (char)0x05d2, (char)0x05d3, (char)0x05d4, (char)0x05d5, (char)0x05d6, (char)0x05d7, (char)0x05d8, (char)0x05d9, (char)0x05da, (char)0x05db, (char)0x05dc, (char)0x05dd, (char)0x05de, (char)0x05df,  // 05d0 .. 05df
            (char)0x05e0, (char)0x05e1, (char)0x05e2, (char)0x05e3, (char)0x05e4, (char)0x05e5, (char)0x05e6, (char)0x05e7, (char)0x05e8, (char)0x05e9, (char)0x05ea, (char)0x05eb, (char)0x05ec, (char)0x05ed, (char)0x05ee, (char)0x05ef,  // 05e0 .. 05ef
            (char)0x05f0, (char)0x05f1, (char)0x05f2, (char)0x05f3, (char)0x05f4, (char)0x05f5, (char)0x05f6, (char)0x05f7, (char)0x05f8, (char)0x05f9, (char)0x05fa, (char)0x05fb, (char)0x05fc, (char)0x05fd, (char)0x05fe, (char)0x05ff   // 05f0 .. 05ff
        };
    }
}
